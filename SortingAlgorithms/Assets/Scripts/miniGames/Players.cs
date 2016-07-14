using UnityEngine;
using System.Collections;

public class Players : MonoBehaviour {
    public float speed;
    public bool upcolliding = false;
    public bool downcolliding = false;
    Vector3 playerposition;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        float xpos = gameObject.transform.position.x + (Input.GetAxis("Horizontal") * speed);

        playerposition = new Vector3( xpos, -25.1F, 5);

        if(xpos > -79.2F&& xpos < 78.6F)
            gameObject.transform.position = playerposition;

       /* if (Input.GetKey("left") && upcolliding == false)
        {
            transform.Translate(0, 0, (Time.deltaTime * speed));
            downcolliding = false;

        }

        if (Input.GetKey("left") && upcolliding == true)
        {
            downcolliding = false;
        }

        if (Input.GetKey("right") && downcolliding == false)
        {
            transform.Translate(0, 0, (-Time.deltaTime * speed));
            upcolliding = false;
        }

        if (Input.GetKey("right") && downcolliding == true)
        {
            upcolliding = false;

        }*/
    }

    /*void OnTriggerEnter()
    {
        upcolliding = true;
        downcolliding = true;
    }*/
}
