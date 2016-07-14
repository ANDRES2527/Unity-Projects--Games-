using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour {

		
	// Update is called once per frame
   
	void Update () {
        adjustFuelBar();
        
	}

    void adjustFuelBar()
    {
        if (Player_Controls.jetPackFuel>0.001f)
        {
            gameObject.transform.localScale = new Vector3(Player_Controls.jetPackFuel,1,1);
        }
    }
}
