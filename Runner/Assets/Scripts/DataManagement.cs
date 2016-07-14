using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataManagement : MonoBehaviour {

    public static DataManagement dataManagement;
    public int currentScore;
    public int highScore;
    public int coinsCollected;

	void Awake ()
    {
        if (dataManagement == null)
        {
            DontDestroyOnLoad(gameObject);
            dataManagement = this;
        }
        else if (dataManagement!= this)
        {
            Destroy(gameObject);
        }
	}

    public void SaveData()
    {
        BinaryFormatter binForm = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");
        gameData data = new gameData();
        data.highScore = highScore;
        data.coinsCollected = coinsCollected;
        binForm.Serialize(file, data);
        file.Close();
    }

    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath+"/gameInfo.dat"))
        {
            BinaryFormatter binForm = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            gameData data = (gameData)binForm.Deserialize(file);
            file.Close();
            highScore = data.highScore;
            coinsCollected = data.coinsCollected;
        }
    }
}

[Serializable]
class gameData
{
    public int highScore;
    public int coinsCollected;



}
