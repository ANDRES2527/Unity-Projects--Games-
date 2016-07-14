using UnityEngine;
using System.Collections;

public class MenuSpawner : MonoBehaviour {

    public GameObject MenuNum;

    int randomPosx;
    int randomPosy;

    void Start()
    {
        Spawn();
    }       
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
            Spawn();
    } 

    void CreatePosition()
    {
        Random.seed = System.DateTime.Now.Millisecond;
        randomPosx = Random.Range(-80,80);
        randomPosy = Random.Range(-23,43);
    }

    void Spawn()
    {
        CreatePosition();
        Instantiate(MenuNum, new Vector3(randomPosx,randomPosy, 0), Quaternion.identity);
    }
}
