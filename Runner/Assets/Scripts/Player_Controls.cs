using UnityEngine;
using System.Collections;

public class Player_Controls : MonoBehaviour {

    public static float jetPackFuel = 2.75f;
    public float jetPackForce = 100.0f;
    private float factor = 1;
    private int cont=0;


    // Update is called once per frame
    void Update()
    {
        if (Screen.height>768 && cont==0)
        {
            factor = Screen.height / 768;
            jetPackForce = jetPackForce * factor;
            cont++;
        }

        if (Input.GetButton("Jump") && jetPackFuel >= 0.001f || Input.GetButton("Jump(1)") && jetPackFuel >= 0.001f)
        {
           
            BoostUp();
        }
    }

    void BoostUp()
    {
        jetPackFuel = Mathf.MoveTowards(jetPackFuel, 0, Time.fixedDeltaTime);
        GetComponent<Rigidbody>().AddForce(new Vector3(0, jetPackForce));
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag=="Ground")
        {
            jetPackFuel = 2.75f;
        }
    }

}
