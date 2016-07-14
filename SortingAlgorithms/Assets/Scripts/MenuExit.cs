using UnityEngine;
using System.Collections;

public class MenuExit : MonoBehaviour {

	void OnMouseDown() {
        transform.localScale *= 2F;
	}
	
	void OnMouseUp() {
        Application.Quit();
	}
}
