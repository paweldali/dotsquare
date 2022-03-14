using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }

    public float[] bestTimes = new float[100];
    public int LastPlayedLevel;

    private void Awake()
    {

        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Load()
    {
        Debug.Log("path to save file = " + Application.persistentDataPath);
        if(File.Exists(Application.persistentDataPath + "/gameData.dat")){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameData.dat", FileMode.Open);
            GameData gameData = (GameData)bf.Deserialize(file);

            bestTimes = gameData.bestTimes;
            LastPlayedLevel = gameData.LastPlayedLevel;
            file.Close();
        }
    }


    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameData.dat");
        GameData gameData = new GameData();

        gameData.bestTimes = bestTimes;
        gameData.LastPlayedLevel = LastPlayedLevel;

        bf.Serialize(file, gameData);
        file.Close();
    }
}

[Serializable]
class GameData{
    public float[] bestTimes;
    public int LastPlayedLevel;
}