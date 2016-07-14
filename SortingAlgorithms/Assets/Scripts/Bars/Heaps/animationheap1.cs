using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class animationheap1 : MonoBehaviour {

    public float conta = 0;
    public GameObject Bars;
    public GameObject itera;


    public bool onPlay;
    ArrayList BarArray = new ArrayList();
    ArrayList HeapBarArray = new ArrayList();
    //ArrayList HeapvalueArray = new ArrayList();

    public int j = 0, k = 0;
    public int h = 0, m = 0, g = 0;
    public int tiempo = 10;
    // Use this for initialization
    void Start () {


        for (int i = 0; i < 80; i++)
        {
            float a = -17 + 0.42F * i;
            float b = -9 + 0.075F * i;
            GameObject BarSpawn = (GameObject)Instantiate(Bars, new Vector3(a, b, 0), Quaternion.identity);
            BarSpawn.transform.localScale += new Vector3(0, 0.15F * i, 0);
            BarSpawn.GetComponent<SpriteRenderer>().color = Color.red;
            Bar otherScript = BarSpawn.GetComponent<Bar>();
            otherScript.RepresentedValue = i;
            otherScript.Position = i;
            BarArray.Add(BarSpawn);
        }

        h = 0; j = 0;
        k = 0; g = 0;

        Disorder();


        onPlay = false;

        GameObject.Find("Dropdown").transform.position = new Vector3(Screen.width - 110, Screen.height - 60, 0);

    }

    // Update is called once per frame
    void OnGUI() {

       

                    if (j > -1 && k % tiempo == 0)
                {
                    if (h < 80 && j % 2 == 0)
                    {
                        ((GameObject)BarArray[h]).GetComponent<SpriteRenderer>().color = Color.blue;
                        InsertInHeap((GameObject)BarArray[h]);
                        j++;
                        h++;
                        g++;
                        itera.GetComponent<TextMesh>().text = g.ToString(); 

                    }

                    if (j < 160 && j % 2 != 0)
                    {
                        ShiftInHeap();
                        j++;
                    }

                    if (j > 159 && (j - 160) % 2 == 0 && j < 160*2)
                    {
                        DeleteInHeap();
                        j++;
                        g++;
                        itera.GetComponent<TextMesh>().text = g.ToString();
                    }

                    if (j > 159 && (j - 160) % 2 != 0)
                    {
                        ShiftInHeap2();
                        j++;
                    }

                    if (j == 159 * 2 + 1)
                        j = -1;
                }
                k++;
        

        if (Input.GetKeyDown(KeyCode.Space))//onPlay == true && Input.GetMouseButtonUp(0) == true ) todavia no funciona :S
        {
            
            
        }
    }

    public void Dropdown_heap(int a)
    {
        tiempo = (GameObject.Find("Dropdown").GetComponent<Dropdown>().value * 10)+10;
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

            first.GetComponent<SpriteRenderer>().color = Color.red;
            second.GetComponent<SpriteRenderer>().color = Color.red;

            ExchangeBars(((GameObject)BarArray[a]), ((GameObject)BarArray[b]));

            stor = ((GameObject)BarArray[a]);
            BarArray[a] = ((GameObject)BarArray[b]);
            BarArray[b] = stor;
        }
    }

    void InsertInHeap(GameObject novo)
    {
        HeapBarArray.Add(novo);
    }

    void ShiftInHeap()
    {
        int n = HeapBarArray.Count -1, a;

        while (n> 0 )
        {
            if (n % 2 == 0)
            {
                a = (n - 2) / 2;

                if (((GameObject)HeapBarArray[a]).transform.localScale.y > ((GameObject)HeapBarArray[n]).transform.localScale.y)
                {
                    ExchangeBars((GameObject)HeapBarArray[a], (GameObject)HeapBarArray[n]);

                    GameObject stor = ((GameObject)HeapBarArray[a]);
                    HeapBarArray[a] = (GameObject)HeapBarArray[n];
                    HeapBarArray[n] = stor;
                }
                else
                    break;

                n = a;
            }
            else
            {
                a = (n - 1) / 2;

                if (((GameObject)HeapBarArray[a]).transform.localScale.y > ((GameObject)HeapBarArray[n]).transform.localScale.y)
                {
                    ExchangeBars((GameObject)HeapBarArray[a], (GameObject)HeapBarArray[n]);

                    GameObject stor = ((GameObject)HeapBarArray[a]);
                    HeapBarArray[a] = (GameObject)HeapBarArray[n];
                    HeapBarArray[n] = stor;
                }
                else
                    break;

                n = a;
            }
        }
        
    }

    void ShiftInHeap2()
    {
        int n = 0;

        while (true)
        {
            if (2 * n + 1 < HeapBarArray.Count - 1)
            {
                int compare = 2 * n + 1;

                if (2 * n + 2 < HeapBarArray.Count - 1 && ((GameObject)HeapBarArray[2 * n + 1]).transform.localScale.y > ((GameObject)HeapBarArray[2 * n + 2]).transform.localScale.y)
                    compare = 2 * n + 2;

                if (((GameObject)HeapBarArray[compare]).transform.localScale.y < ((GameObject)HeapBarArray[n]).transform.localScale.y)
                {
                    ExchangeBars((GameObject)HeapBarArray[compare], (GameObject)HeapBarArray[n]);

                    GameObject stor = ((GameObject)HeapBarArray[compare]);
                    HeapBarArray[compare] = (GameObject)HeapBarArray[n];
                    HeapBarArray[n] = stor;

                    n = compare;
                }
                else
                    break;
            }
            else
                break;

        }
    }

    void DeleteInHeap()
    {
        int last = HeapBarArray.Count -1;

        if (last > -1) // andy aqui ponel 2 en lugar del -1 y pudes ver que el arreglo queda mal pero no se porque .... hay que revisar bien
        {
            float x = ((GameObject)HeapBarArray[0]).transform.localPosition.x;
            float y = ((GameObject)HeapBarArray[0]).transform.localPosition.y;

            for (int i = last; i > -1; i--)
            {
                Vector3 move = new Vector3(((GameObject)HeapBarArray[i]).transform.localPosition.x + 0.42F, ((GameObject)HeapBarArray[i]).transform.localPosition.y, 0);

                GameObject moment = (GameObject)HeapBarArray[i];
                moment.transform.localPosition = move;
            }

            BarArray[m] = (GameObject)Instantiate((GameObject)HeapBarArray[0], new Vector3(x, y, 0), Quaternion.identity);
            ((GameObject)BarArray[m]).GetComponent<SpriteRenderer>().color = Color.white;
            m++;

            ExchangeBars((GameObject)HeapBarArray[0], (GameObject)HeapBarArray[last]);
            HeapBarArray[0] = (GameObject)HeapBarArray[last];
            GameObject muerto = (GameObject)HeapBarArray[last];
            HeapBarArray.RemoveAt(last);
           // Destroy(muerto);
        }



    }
}

