using UnityEngine;
using System.Collections;

public class cont : MonoBehaviour {
    public int conta = 0; 
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        /*if (conta < 3)
            conta += Time.deltaTime;
        if (conta > 3)
        {
            print("WAITED 3 SECONDS");
            conta = 0;
        }*/
        if(Input.GetMouseButtonUp(0)==true)
        conta ++;
     }
   
}
