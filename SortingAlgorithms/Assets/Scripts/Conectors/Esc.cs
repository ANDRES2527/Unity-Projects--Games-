using UnityEngine;
using System.Collections;

public class Esc : MonoBehaviour {

    public int i;

	void OnGUI () {
	    if(Input.GetKeyUp(KeyCode.Escape))
            Application.LoadLevel(i);
	}
}
