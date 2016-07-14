using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {
    public Transform bullet;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) )
        {
            Transform shot = Instantiate(bullet, transform.position, Quaternion.identity) as Transform;
        }

	}
}
