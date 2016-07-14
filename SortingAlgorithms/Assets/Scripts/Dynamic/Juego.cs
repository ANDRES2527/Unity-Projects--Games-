using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Juego : MonoBehaviour {

    public GameObject toggle;
    public bool encontro = false;
    private int[] valores = new int[10];
    private GameObject[] players = new GameObject[10];
    private GameObject[] labels = new GameObject[10];
    private string[] name_players = new string[10];
    public int[,] respuestas = new int[40, 2];
    public int cont = 0;
    public int peleador1;
    public int peleador2;
    public int limite_d;
    public int limite_i;
    public bool ida;
    public bool fin;
    int tiempo_pelea = 0;
    Vector3 pos_original_p1 = new Vector3();
    Vector3 pos_original_p2 = new Vector3();
    int iter = -1;
    int vidas = 2;
    
    void Start()
    {
        fin = true;
        limite_i = 0;
        limite_d = players.Length - 1;
        ida = true;
        GameObject.Find("Button").transform.position = new Vector3(GameObject.Find("Button").transform.position.x, Screen.height / 12, GameObject.Find("Button").transform.position.z);
        GameObject.Find("Button (1)").transform.position = new Vector3(GameObject.Find("Button (1)").transform.position.x, Screen.height / 12, GameObject.Find("Button (1)").transform.position.z);
        GameObject.Find("Text").transform.position = new Vector3((Screen.width / 2) + 50, Screen.height / 20, GameObject.Find("Text").transform.position.z);
        GameObject.Find("Text").GetComponent<Text>().text = "";
        GameObject.Find("Text").GetComponent<Text>().color = Color.white;
        int poder = 100;
        float a = 0;
        for (int i = 0; i < 10; i++)
        {
            a += (Screen.width / 10.3f);
            GameObject toggle1 = (GameObject)Instantiate(toggle, new Vector3(a, Screen.height / 7, 0), Quaternion.identity);
            toggle1.GetComponent<Text>().font = GameObject.Find("Button").GetComponentInChildren<Text>().font;
            toggle1.transform.SetParent(this.GetComponentInChildren<Canvas>().transform);
            toggle1.transform.name = "toggle" + i;
            toggle1.GetComponentInChildren<Text>().text = "Poder:" + " " + poder;
            labels[i] = toggle1;
            valores[i] = poder;
            poder = poder - 10;

        }
        int cont = 1;
        for (int i = 0; i < name_players.Length; i++)
        {
            if (i <= 2)
            {
                name_players[i] = "MedievalKnight" + cont;
                cont++;
                if (i == 2)
                {
                    cont = 1;
                }
            }
            else
            {
                if (i <= 5)
                {
                    name_players[i] = "Archer" + cont;
                    cont++;
                    if (i == 5)
                    {
                        cont = 1;
                    }
                }
                else
                {
                    if (i <= 7)
                    {
                        name_players[i] = "Necromancer" + cont;
                        cont++;
                        if (i == 7)
                        {
                            cont = 1;
                        }
                    }
                    else
                    {
                        name_players[i] = "Wizard" + cont;
                        cont++;
                    }
                }
            }
        }
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = GameObject.Find(name_players[i]);
        }

        GameObject.Find("Image").transform.position = new Vector3(Screen.width-40, Screen.height-40,0);
        GameObject.Find("Vidas").transform.position = new Vector3(Screen.width , Screen.height - 40, 0);
        Desordenar();
        Saltar();
        respuestas = shaker_sort_arreglo_iteraciones(valores);

    }


    void Desordenar()
    {
        Random.seed = System.DateTime.Now.Millisecond;
        int a = 0, b = 0;
        Vector3 pos;
        GameObject obj;
        int aux;
        for (int i = 0; i < players.Length; i++)
        {
            a = Random.Range(0, players.Length);
            b = Random.Range(0, players.Length);
            pos = players[a].transform.position;
            players[a].transform.position = players[b].transform.position;
            players[b].transform.position = pos;
            obj = players[a];
            players[a] = players[b];
            players[b] = obj;
            aux = valores[a];
            valores[a] = valores[b];
            valores[b] = aux;
            pos = labels[a].transform.position;
            labels[a].transform.position = labels[b].transform.position;
            labels[b].transform.position = pos;
            obj = labels[a];
            labels[a] = labels[b];
            labels[b] = obj;
        }
    }
    public void Saltar()
    {
        iter++;
        if (limite_i + 1 == limite_d)
        {
            fin = false;
            for (int i = 0; i < players.Length; i++)
            {
                players[i].GetComponent<Animator>().SetBool("Jump", false);
            }
            players[limite_d].GetComponent<Animator>().SetBool("Jump", true);
            players[limite_i].GetComponent<Animator>().SetBool("Jump", true);
            peleador1 = limite_i;
            peleador2 = limite_d;
        }
        if (fin)
        {

            if (ida)
            {
                if (cont > 0)
                {
                    players[cont - 1].GetComponent<Animator>().SetBool("Jump", false);
                }
                peleador1 = cont;
                peleador2 = cont + 1;
                players[peleador1].GetComponent<Animator>().SetBool("Jump", true);
                players[peleador2].GetComponent<Animator>().SetBool("Jump", true);
                cont++;
                


                if (cont == limite_d)
                {
                    ida = false;
                    limite_d--;

                }
            }
            else
            {
                if (cont < players.Length - 1)
                {
                    players[cont + 1].GetComponent<Animator>().SetBool("Jump", false);
                }
                peleador1 = cont;
                peleador2 = cont - 1;
                players[peleador1].GetComponent<Animator>().SetBool("Jump", true);
                players[peleador2].GetComponent<Animator>().SetBool("Jump", true);
                cont--;
                if (cont == limite_i)
                {
                    ida = true;
                    limite_i++;
                }
            }

        }
    }

    public void Pelear()
    {
        GameObject.Find("Button").GetComponent<Button>().interactable = false;
        GameObject.Find("Button (1)").GetComponent<Button>().interactable = false;
        
            if (vidas >= 1)
            {
                bool continuar = true;
                respuestas = shaker_sort_arreglo_iteraciones(valores);
                if (peleador2 - 1 == limite_d && valores[peleador1] > valores[peleador2])
                {
                    ida = true;
                }
                else if (peleador2 - 1 == limite_d)
                {
                    ida = true;
                    if (ida && valores[peleador1] < valores[peleador2])
                    {
                        GameObject.Find("Text").GetComponent<Text>().text = "Mala jugada";
                        ida = false;
                        vidas--;
                        if (vidas >= 1)
                        {
                            Saltar();
                            GameObject.Find("Button").GetComponent<Button>().interactable = true;
                            GameObject.Find("Button (1)").GetComponent<Button>().interactable = true;
                        }
                    }
                    continuar = false;
                }
                if (peleador2 + 1 == limite_i && valores[peleador1] < valores[peleador2])
                {
                    ida = false;
                }
                else if (peleador2 + 1 == limite_i)
                {
                    ida = false;
                    if (!ida && valores[peleador1] > valores[peleador2])
                    {
                        GameObject.Find("Text").GetComponent<Text>().text = "Mala jugada";
                        ida = true;
                        vidas--;
                        if (vidas >= 1)
                        {
                            Saltar();
                            GameObject.Find("Button").GetComponent<Button>().interactable = true;
                            GameObject.Find("Button (1)").GetComponent<Button>().interactable = true;
                        }
                    }
                    continuar = false;
                }

                if (continuar)
                {
                    if (ida && valores[peleador1] < valores[peleador2])
                    {
                        GameObject.Find("Text").GetComponent<Text>().text = "Mala jugada";
                        vidas--;
                        if (vidas >= 1)
                        {
                            Saltar();
                            GameObject.Find("Button").GetComponent<Button>().interactable = true;
                            GameObject.Find("Button (1)").GetComponent<Button>().interactable = true;
                        }
                    }
                    else
                    {
                        if (!ida && valores[peleador1] > valores[peleador2])
                        {
                            GameObject.Find("Text").GetComponent<Text>().text = "Mala jugada";
                            vidas--;
                            if (vidas >= 1)
                            {
                                Saltar();
                                GameObject.Find("Button").GetComponent<Button>().interactable = true;
                                GameObject.Find("Button (1)").GetComponent<Button>().interactable = true;
                            }
                        }
                        else
                        {
                             GameObject.Find("Button").GetComponent<Button>().interactable = false;
                             GameObject.Find("Button (1)").GetComponent<Button>().interactable = false;
                        if (tiempo_pelea < 60)
                            {
                                tiempo_pelea++;
                                players[peleador1].GetComponent<Animator>().SetBool("Jump", false);
                                players[peleador2].GetComponent<Animator>().SetBool("Jump", false);

                                if (tiempo_pelea == 1)
                                {
                                    pos_original_p1 = players[peleador1].transform.position;
                                    pos_original_p2 = players[peleador2].transform.position;
                                    players[peleador1].transform.Rotate(Vector3.down * 65);
                                    players[peleador2].transform.Rotate(Vector3.up * 65);
                                }
                                players[peleador1].transform.position = new Vector3(154.25f, 94.25f, 1.5f);
                                players[peleador2].transform.position = new Vector3(156.25f, 94.25f, 1.5f);
                                if (tiempo_pelea >= 1 && tiempo_pelea < 5)
                                {
                                    players[peleador1].GetComponent<Animator>().SetBool("Attack", true);
                                    players[peleador2].GetComponent<Animator>().SetBool("Defend", true);
                                }

                                if (tiempo_pelea >= 5 && tiempo_pelea < 25)
                                {
                                    if (tiempo_pelea == 5)
                                    {
                                        players[peleador1].GetComponent<Animator>().SetBool("Attack", false);
                                        players[peleador2].GetComponent<Animator>().SetBool("Defend", false);
                                    }
                                    players[peleador2].GetComponent<Animator>().SetBool("Attack", true);
                                    players[peleador1].GetComponent<Animator>().SetBool("Defend", true);
                                }
                                if (tiempo_pelea >= 25)
                                {
                                    players[peleador2].GetComponent<Animator>().SetBool("Attack", false);
                                    players[peleador1].GetComponent<Animator>().SetBool("Defend", false);
                                    if (ida)
                                        players[peleador2].GetComponent<Animator>().SetBool("Die", true);
                                    else
                                        players[peleador1].GetComponent<Animator>().SetBool("Die", true);
                                }
                                InvokeRepeating("Pelear", 1f, 1f);
                            }
                            else
                            {

                                players[peleador2].GetComponent<Animator>().SetBool("Attack", false);
                                players[peleador1].GetComponent<Animator>().SetBool("Defend", false);
                                players[peleador1].GetComponent<Animator>().SetBool("Attack", false);
                                players[peleador2].GetComponent<Animator>().SetBool("Defend", false);
                                players[peleador1].transform.position = pos_original_p2;
                                players[peleador2].transform.position = pos_original_p1;
                                players[peleador1].transform.Rotate(Vector3.down * -65);
                                players[peleador2].transform.Rotate(Vector3.up * -65);

                                players[peleador2].GetComponent<Animator>().SetBool("Die", false);
                                players[peleador1].GetComponent<Animator>().SetBool("Die", false);
                                GameObject obj = players[peleador1];
                                players[peleador1] = players[peleador2];
                                players[peleador2] = obj;
                                int aux = valores[peleador1];
                                valores[peleador1] = valores[peleador2];
                                valores[peleador2] = aux;
                                Vector3 a = labels[peleador1].transform.position;
                                labels[peleador1].transform.position = labels[peleador2].transform.position;
                                labels[peleador2].transform.position = a;
                                obj = labels[peleador1];
                                labels[peleador1] = labels[peleador2];
                                labels[peleador2] = obj;
                                tiempo_pelea = 0;
                                if (peleador2 - 1 == limite_d)
                                {
                                    ida = false;
                                }
                                if (peleador2 + 1 == limite_i)
                                {
                                    ida = true;
                                }

                                Saltar();
                                GameObject.Find("Button").GetComponent<Button>().interactable = true;
                                GameObject.Find("Button (1)").GetComponent<Button>().interactable = true;

                                CancelInvoke();

                            }
                        }

                    }
                }
           
        }
            else
            {
                GameOver();
            }
        
        
    }
    public void continuar_sin_pelear()
    {
        
            GameObject.Find("Button").GetComponent<Button>().interactable = false;
            GameObject.Find("Button (1)").GetComponent<Button>().interactable = false;
        
            if (vidas >= 1)
            {
                bool continuar = true;
                respuestas = shaker_sort_arreglo_iteraciones(valores);
                if (peleador2 - 1 == limite_d && valores[peleador1] < valores[peleador2])
                {
                    ida = true;
                }
                else if (peleador2 - 1 == limite_d)
                {
                    ida = true;
                    if (ida && valores[peleador1] > valores[peleador2])
                    {
                        GameObject.Find("Text").GetComponent<Text>().text = "Mala jugada";
                        ida = false;
                        vidas--;
                        if (vidas >= 1)
                        {
                            Pelear();
                            GameObject.Find("Button").GetComponent<Button>().interactable = true;
                            GameObject.Find("Button (1)").GetComponent<Button>().interactable = true;
                        }
                    }
                    continuar = false;
                }
                if (peleador2 + 1 == limite_i && valores[peleador1] > valores[peleador2])
                {
                    ida = false;
                }
                else if (peleador2 + 1 == limite_i)
                {
                    ida = false;
                    if (!ida && valores[peleador1] < valores[peleador2])
                    {
                        GameObject.Find("Text").GetComponent<Text>().text = "Mala jugada";
                        ida = true;
                        vidas--;
                        if (vidas >= 1)
                        {
                            Pelear();
                            GameObject.Find("Button").GetComponent<Button>().interactable = true;
                            GameObject.Find("Button (1)").GetComponent<Button>().interactable = true;
                        }
                    }
                    continuar = false;
                }

                if (continuar)
                {
                    if (ida && valores[peleador1] > valores[peleador2])
                    {

                        vidas--;
                        if (vidas >= 1)
                        {
                            Pelear();
                            GameObject.Find("Button").GetComponent<Button>().interactable = true;
                            GameObject.Find("Button (1)").GetComponent<Button>().interactable = true;
                        }
                        GameObject.Find("Text").GetComponent<Text>().text = "Mala jugada";
                    }
                    else
                    {
                        if (!ida && valores[peleador1] < valores[peleador2])
                        {
                            GameObject.Find("Text").GetComponent<Text>().text = "Mala jugada";
                            vidas--;
                            if (vidas >= 1)
                            {
                                Pelear();
                                GameObject.Find("Button").GetComponent<Button>().interactable = true;
                                GameObject.Find("Button (1)").GetComponent<Button>().interactable = true;
                            }
                        }
                        else
                        {
                            if (peleador2 - 1 == limite_d)
                            {
                                ida = false;
                            }
                            if (peleador2 + 1 == limite_i)
                            {
                                ida = true;
                            }
                            Saltar();
                            GameObject.Find("Button").GetComponent<Button>().interactable = true;
                            GameObject.Find("Button (1)").GetComponent<Button>().interactable = true;
                        }
                    }
                }
            }
            else
            {
                GameOver();
            }
        
    }

    public void GameOver()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<Animator>().SetBool("Jump", false);
            players[i].GetComponent<Animator>().SetBool("Die_d", true);
        }
        GameObject.Find("Button").GetComponent<Button>().interactable = false;
        GameObject.Find("Button (1)").GetComponent<Button>().interactable = false;

    }
    void Update()
    {
        GameObject.Find("Vidas").GetComponent<Text>().text = ""+vidas;
        if (vidas == 0)
            GameOver();
    }
    public  int[,] shaker_sort_arreglo_iteraciones(int[] arr)
    {
        int a, b, aux;
        int[,] resp = new int[100, 2];
        a = 0;
        b = arr.Length - 1;
        int cont_pos = 0;

        while (a != b)              //numero de elementos impar
        {
            if (arr.Length % 2 == 0)
                if (a + 1 == b) //numero de elementos par
                    break;
            for (int i = a; i < b; i++)     // recorre del incio al final del actual repositorio 
            {
                if (arr[i] > arr[i + 1])    //compara los elementos para ordenarlos
                {
                    //aux = arr[i];
                   // arr[i] = arr[i + 1];
                   // arr[i + 1] = aux;
                    resp[cont_pos, 0] = i;
                    resp[cont_pos, 1] = i + 1;
                    cont_pos++;
                }
                else
                {
                    resp[cont_pos, 0] = -1;
                    resp[cont_pos, 1] = -1;
                    cont_pos++;
                }
            }
            for (int j = b - 1; j > a; j--)     // recorre del final al inicio del actual repositorio
            {
                if (arr[j] < arr[j - 1])        //compara los elementos para ordenarlos
                {
                    //aux = arr[j];
                    //arr[j] = arr[j - 1];
                    //arr[j - 1] = aux;
                    resp[cont_pos, 0] = j;
                    resp[cont_pos, 1] = j - 1;
                    cont_pos++;
                }
                else
                {
                    resp[cont_pos, 0] = -1;
                    resp[cont_pos, 1] = -1;
                    cont_pos++;
                }
            }
            a = a + 1;                      //recorta el arreglo x los dos lados
            b = b - 1;
        }
        return resp;
    }
}
