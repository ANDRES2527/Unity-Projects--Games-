using UnityEngine;
using System.Collections;

public class espera : MonoBehaviour {
    bool activo = false;
    public int cont = 0;
    public int x_contar = 3;
	// Use this for initialization
	void Start () {
        
    }
	
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(3);
        print("waited");
    }
    void TimerInvoke()
    {
        if (cont < x_contar)
            cont++;
        else
            CancelInvoke("TimerInvoke");
    }
    void callShoot()
    {
        if (!activo)
            StartCoroutine("Shoot");
        else
            StopCoroutine("Shoot");
    }
	// Update is called once per frame
	void FixedUpdate () {
        Time.timeScale = 1.5f;
        if (cont == 3)
        {
            print("waited");
            cont = 0;
        }
        else
            InvokeRepeating("TimerInvoke",1,1);


    }
}
