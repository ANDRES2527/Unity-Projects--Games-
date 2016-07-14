using UnityEngine;
using System.Collections;

public class pausa : MonoBehaviour {

   
    // Update is called once per frame
    void Update () {
        Time.timeScale = 0.01f;
        StartCoroutine("wait");
	}
    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);

    }

}
