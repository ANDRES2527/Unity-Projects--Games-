using UnityEngine;
using System.Collections;

public class Guns : MonoBehaviour {
        
	// Use this for initialization
	void Start () {

        Destroy(gameObject, 1);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0,1,0);
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "target")
        {
            Destroy(gameObject);
            Destroy(other);

        }

    }

}
