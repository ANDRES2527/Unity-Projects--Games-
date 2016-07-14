using UnityEngine;
using System.Collections;

public class MenuNum : MonoBehaviour {

    public int velocity = 500;

    int random;
    Rigidbody rb;
    TextMesh  text2;

    void Awake()
    {
        Random.seed = System.DateTime.Now.Millisecond ;
        random = Random.Range(1, 99);
        rb = GetComponent<Rigidbody>();
        if (random/2 == 0)
            rb.AddForce(new Vector3(velocity, velocity, 0), 0);
        else
            rb.AddForce(new Vector3(velocity, -velocity, 0), 0);

        text2 = GetComponent<TextMesh>();
        text2.text ="" + random;
    }
}
