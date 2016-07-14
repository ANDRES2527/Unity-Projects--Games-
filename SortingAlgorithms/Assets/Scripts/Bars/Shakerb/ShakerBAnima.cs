using UnityEngine;
using System.Collections;

public class ShakerBAnima : MonoBehaviour {

    public GameObject Bars;

    public bool onPlay ;
    ArrayList BarArray = new ArrayList();
   public int cont = 0;
  
    public int secToWait = 3;
    //Task t = new Task(SomeCoroutine(), true);

    void Start () {

       
        for (int i =0; i < 80; i++)
        {
            float a = -17 + 0.42F * i;
            float b = -9 + 0.075F * i;          
            GameObject BarSpawn = (GameObject)Instantiate(Bars, new Vector3(a,b, 0), Quaternion.identity);
            BarSpawn.transform.localScale += new Vector3(0,0.15F*i ,0);
            Bar otherScript = BarSpawn.GetComponent<Bar>();
            otherScript.RepresentedValue = i;
            otherScript.Position = i;
            BarArray.Add(BarSpawn);
          
        }
        Disorder();
        
       
        onPlay = false;
	}

    void TimerInvoke()
    {
        if (cont < secToWait)
            cont++;
        else
            CancelInvoke("TimerInvoke");
    }

    void Update () {

        if (Input.GetKeyDown(KeyCode.G))
        {
            print("g");
            //cont = 0;

            InvokeRepeating("TimerInvoke", 1, 1);
        }
        if (onPlay == false && Input.GetMouseButtonUp(0) == true )
        {

           
            //InvokeRepeating("TimerInvoke", 1, 1);
            ShakerSort();
            //Disorder();
            //yield return new WaitForSeconds(3);
            onPlay = true;
            //cont++;
        }

        if (Input.GetKeyDown(KeyCode.Space))//onPlay == true && Input.GetMouseButtonUp(0) == true )
        {
            Disorder();
            onPlay = false;
        }

        
        
    }

    /*IEnumerator SomeCoroutine()
    {
        Disorder();

        ShakerSort();
        //Disorder();
        yield return new WaitForSeconds(3);
    }*/

        
   
    void ExchangeBarsO(GameObject a, GameObject b)
    {
        //cont = 0;       

        if (cont == 3)
       {
            float stor, stor2;
            stor2 = a.transform.position.x;
            stor = a.transform.position.y;
            a.transform.position = new Vector3(b.transform.position.x, stor, 0);
            stor = b.transform.position.y;
            b.transform.position = new Vector3(stor2, stor, 0);
            //cont = 0;
       }
        


    }
    void ExchangeBars(GameObject a, GameObject b)
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

    void ShakerSort()
    {
        int i, j, k = 0, l = BarArray.Count - 1;
      
        while (true)
        {
            GameObject a, b;
            Time.timeScale = 0;
           
            object stor;
            for (i = k; i < l; i++)
            {
                a = ((GameObject)BarArray[i]);
                b = ((GameObject)BarArray[i+1]);
                Bar first = a.GetComponent<Bar>();
                Bar second = b.GetComponent<Bar>();

                if (first.RepresentedValue > second.RepresentedValue)
                {
                    ExchangeBarsO(a,b);
                    stor = ((GameObject)BarArray[i]);
                    BarArray[i] = ((GameObject)BarArray[i+1]);
                    BarArray[i+1] = stor;
                }
            }

            for (j = l; j > 0; j--)
            {
                a = ((GameObject)BarArray[j-1]);
                b = ((GameObject)BarArray[j]);
                Bar first = a.GetComponent<Bar>();
                Bar second = b.GetComponent<Bar>();

                if (first.RepresentedValue > second.RepresentedValue)
                {
                    ExchangeBarsO(a,b);
                    stor = ((GameObject)BarArray[j-1]);
                    BarArray[j-1] = ((GameObject)BarArray[j]);
                    BarArray[j] = stor;
                }
            }

            
           
            k++;
            l--;
            if (l == k && BarArray.Count % 2 != 0)
                break;

            if (BarArray.Count % 2 == 0 && k == l + 1)
                break;
        }
    }
}
