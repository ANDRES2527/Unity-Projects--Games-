using UnityEngine;
using System.Collections;

public class Forward : MonoBehaviour {

    public int i; 

    void OnMouseDown()
    {
        transform.localScale *= 0.5F;
    }

    void OnMouseUp()
    {
        Application.LoadLevel(i);
    }
}
