using UnityEngine;
using System.Collections;

public class Bar : MonoBehaviour {

    int representedValue= 0;
    int position = 0;
    bool selected = false;
    
    
    public int Position
    {
        get { return position; }
        set { position = value; }
    }

    public int RepresentedValue
    {
        get { return representedValue; }
        set { representedValue = value; }
    }

    public bool Selected
    {
        get { return selected; }
        set { selected = value; }
    }
}
