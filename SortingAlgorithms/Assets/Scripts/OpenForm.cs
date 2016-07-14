using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class OpenForm : MonoBehaviour {

    // Use this for initialization
    void OnMouseUp()
    {
        try
        {
            Process.Start("C:\\SortingAlgorithmsHeapSort\\SortingAlgorithmsHeapSort\\obj\\x86\\Debug\\SortingAlgorithmsHeapSort.exe");
        }
        catch (System.Exception e)
        {
            try { Process.Start("D:\\SortingAlgorithmsHeapSort\\SortingAlgorithmsHeapSort\\obj\\x86\\Debug\\SortingAlgorithmsHeapSort.exe"); }
            catch (System.Exception o)
            { Process.Start("E:\\SortingAlgorithmsHeapSort\\SortingAlgorithmsHeapSort\\obj\\x86\\Debug\\SortingAlgorithmsHeapSort.exe"); }
        }


    }

    // Update is called once per frame
    void OnMouseDown()
    {
        //transform.localScale *= .2F;
    }
}
