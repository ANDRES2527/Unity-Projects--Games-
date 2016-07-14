using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {

    public int i;

    void OnMouseDown()
    {
        transform.localScale *= 2F;
    }

    void OnMouseUp()
    {
        Application.LoadLevel(i);
    }
}
