using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class contador : MonoBehaviour {

    public float conta = 0;
    public GameObject Bars;
    public GameObject itera;

    public bool onPlay;
    ArrayList BarArray = new ArrayList();
    int k = 0, l = 0, g = 0;
    int i_p = 0;
    int j_p=0;
    float tiempo=0;

    void Start()
    {

        
        for (int i = 0; i < 80; i++)
        {
            float a = -17 + 0.42F * i;
            float b = -9 + 0.075F * i;
            GameObject BarSpawn = (GameObject)Instantiate(Bars, new Vector3(a, b, 0), Quaternion.identity);
            BarSpawn.transform.localScale += new Vector3(0, 0.15F * i, 0);
            Bar otherScript = BarSpawn.GetComponent<Bar>();
            otherScript.RepresentedValue = i;
            otherScript.Position = i;
            BarArray.Add(BarSpawn);
          

        }
        i_p = 0;
        j_p= BarArray.Count - 1;
        l = BarArray.Count - 1;
      
        Disorder();


        onPlay = false;

        GameObject.Find("Dropdown").transform.position = new Vector3(Screen.width - 110,Screen.height-60,0);
    }
    // Update is called once per frame
    void OnGUI () {
        
        
         if (conta < tiempo)
             conta += Time.deltaTime;
         if (conta >= tiempo)
         {
        
     
        if (i_p >= 1)
        {
            if (i_p == 1)
            {
                ((GameObject)BarArray[0]).GetComponent<SpriteRenderer>().color = Color.white;
            }
            else
            {
                ((GameObject)BarArray[i_p - 1]).GetComponent<SpriteRenderer>().color = Color.white;
                ((GameObject)BarArray[i_p - 2]).GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        if (j_p<= l-1)
        {
            if (j_p == l-1)
            {
                ((GameObject)BarArray[l]).GetComponent<SpriteRenderer>().color = Color.white;
            }
            else
            {
                ((GameObject)BarArray[j_p + 1]).GetComponent<SpriteRenderer>().color = Color.white;
                ((GameObject)BarArray[j_p + 2]).GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        if (j_p==k && i_p==l)
            {
                k++;
                l--;
                i_p = k;
                j_p = l;
            }
            else
            {
                if (i_p < l)
                {
                    ShakerIda(i_p);
                    g =g+ 1;
                    itera.GetComponent<TextMesh>().text = g + "";
                    i_p++;
                }
                else if (j_p > k)
                {
                    ShakerVuelta(j_p);
                    g = g+ 1;
                    itera.GetComponent<TextMesh>().text = g + "";
                    j_p--;
                }
                conta = 0;
            }
            
        }
        if (Input.GetMouseButtonUp(0) == true)
        {

                //ShakerSort();
                //k++;
                //l--;
                //Disorder();

        }

        if (Input.GetKeyDown(KeyCode.Space))//onPlay == true && Input.GetMouseButtonUp(0) == true )
        {
            Disorder();
            onPlay = false;
            for (int i = 0; i <= l; i++)
            {
                ((GameObject)BarArray[i]).GetComponent<SpriteRenderer>().color = Color.white;
            }
            l = BarArray.Count - 1;
            k = 0;
            j_p= BarArray.Count - 1;
            i_p = 0;
            g = 0;
        }

    }
   
    public void Dropdown_c(int a)
    {
       tiempo= GameObject.Find("Dropdown").GetComponent<Dropdown>().value*0.25f;
    }
    void ExchangeBars(GameObject a,GameObject b)
    {

       
        float stor, stor2;
            stor2 = a.transform.position.x;
            stor = a.transform.position.y;
           
            a.transform.position = new Vector3(b.transform.position.x, stor, 0);
            stor = b.transform.position.y;
            b.transform.position = new Vector3(stor2, stor, 0);

    }
    
    void Disorder() // No estoy usando posicion  pilas para borrar eso de Bar prefab/para comprobacion talvez?
    {
        Random.seed = System.DateTime.Now.Millisecond;
        int a = 0, b = 0;
        object stor;


        for (int i = 0; i < 240; i++)
        {
            a = Random.Range(0, 80);
            b = Random.Range(0, 80);

            Bar first = ((GameObject)BarArray[a]).GetComponent<Bar>();
            Bar second = ((GameObject)BarArray[b]).GetComponent<Bar>();

            ExchangeBars(((GameObject)BarArray[a]), ((GameObject)BarArray[b]));

            stor = ((GameObject)BarArray[a]);
            BarArray[a] = ((GameObject)BarArray[b]);
            BarArray[b] = stor;
        }
    }

    void ShakerIda(int i1)
    {
        GameObject a, b;       

        object stor;
       
        a = ((GameObject)BarArray[i1]);
        b = ((GameObject)BarArray[i1 + 1]);
        a.GetComponent<SpriteRenderer>().color = Color.red;
        b.GetComponent<SpriteRenderer>().color = Color.red;

        Bar first = a.GetComponent<Bar>();
            Bar second = b.GetComponent<Bar>();

            if (first.RepresentedValue > second.RepresentedValue)
            {
                ExchangeBars(a, b);
                stor = ((GameObject)BarArray[i1]);
                BarArray[i1] = ((GameObject)BarArray[i1 + 1]);
                BarArray[i1 + 1] = stor;
            }
        
    }
    void ShakerVuelta(int j1)
    {
        GameObject a, b;
      

        object stor;
        a = ((GameObject)BarArray[j1 - 1]);
        b = ((GameObject)BarArray[j1]);
        a.GetComponent<SpriteRenderer>().color = Color.red;
        b.GetComponent<SpriteRenderer>().color = Color.red;

        Bar first = a.GetComponent<Bar>();
        Bar second = b.GetComponent<Bar>();

        if (first.RepresentedValue > second.RepresentedValue)
        {
            ExchangeBars(a, b);
            stor = ((GameObject)BarArray[j1 - 1]);
            BarArray[j1 - 1] = ((GameObject)BarArray[j1]);
            BarArray[j1] = stor;
        }
    }

void ShakerSort()
    {
        int i, j;

       /* while (true)*/
        //{
            GameObject a, b;
           

            object stor;
            for (i = k; i < l; i++)
            {
                a = ((GameObject)BarArray[i]);
                b = ((GameObject)BarArray[i + 1]);
                Bar first = a.GetComponent<Bar>();
                Bar second = b.GetComponent<Bar>();

                if (first.RepresentedValue > second.RepresentedValue)
                {
                    ExchangeBars(a, b);
                    stor = ((GameObject)BarArray[i]);
                    BarArray[i] = ((GameObject)BarArray[i + 1]);
                    BarArray[i + 1] = stor;
                }
            }

            for (j = l; j > k; j--)
            {
                a = ((GameObject)BarArray[j - 1]);
                b = ((GameObject)BarArray[j]);
                Bar first = a.GetComponent<Bar>();
                Bar second = b.GetComponent<Bar>();

                if (first.RepresentedValue > second.RepresentedValue)
                {
                    ExchangeBars(a, b);
                    stor = ((GameObject)BarArray[j - 1]);
                    BarArray[j - 1] = ((GameObject)BarArray[j]);
                    BarArray[j] = stor;
                }
            }



           // k++;
           // l--;
            /*if (l == k && BarArray.Count % 2 != 0)
                break;

            if (BarArray.Count % 2 == 0 && k == l + 1)
                break;*/
        //}
    }
}
