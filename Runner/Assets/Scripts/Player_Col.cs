using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_Col : MonoBehaviour {

    private int coins=0;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag=="Enemy")
        {
            playerDies();
        }
    }
    void OnTriggerEnter(Collider trig)
    {
        if (trig.gameObject.tag=="Coin")
        {
            //DataManagement.dataManagement.coinsCollected++;
            DataManagement.dataManagement.coinsCollected++;
            DataManagement.dataManagement.currentScore++;
            //play audio effect 
            Destroy(trig.gameObject);
        }
    }

    void playerDies()
    {
        //play death audio
        DataManagement.dataManagement.SaveData();
        //activate UI for restarting game
        Application.LoadLevel(1);
    }
   
}
