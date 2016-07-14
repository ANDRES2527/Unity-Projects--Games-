using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public GameObject scoreUI;
    public GameObject highScoreUI;

	void Update () {
        if (DataManagement.dataManagement.currentScore>DataManagement.dataManagement.highScore)
        {
            DataManagement.dataManagement.highScore = DataManagement.dataManagement.currentScore;
        }
        scoreUI.GetComponent<Text>().text = ("Score:" +" "+ DataManagement.dataManagement.currentScore.ToString());
        highScoreUI.GetComponent<Text>().text = ("High Score:"+" "+DataManagement.dataManagement.highScore.ToString());
	}
}
