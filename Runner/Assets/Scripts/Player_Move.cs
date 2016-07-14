using UnityEngine;
using System.Collections;

public class Player_Move : MonoBehaviour {

    public static int playerSpeed = 6;
	
	// Update is called once per frame
	void FixedUpdate () {

        //gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
        gameObject.transform.Translate(playerSpeed * Time.fixedDeltaTime*-1,0,0);
        
	}
}
