using UnityEngine;
using System.Collections;

public class SkipIntro : MonoBehaviour {

    void Update()
    {
        if (Input.GetButton("Jump") || Input.GetButton("Jump(1)"))
        {
            Application.LoadLevel(1);
        }
    }
}
