using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{

    public static GameSaveManager instance;

    public HologramItemData[] dataObjects;

    public void Awake()
    {
        instance = this;

        LoadGame();
    }
     public bool IsSaveFile()
    {
        return Directory.Exists(Application.persistentDataPath + "/game_save");
    }

    public void SaveGame()
    {
        if (!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save");
        }
        if (!Directory.Exists(Application.persistentDataPath + "/game_save/hologram_data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save/hologram_data");
        }
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + "/game_save/hologram_data/hologram_save.txt");

        var json = JsonUtility.ToJson(dataObjects);
        bf.Serialize(file, json);
        file.Close();
    }

    public void LoadGame()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/game_save/hologram_data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save/hologram_data");
        }

        BinaryFormatter bf = new BinaryFormatter();

        if (File.Exists(Application.persistentDataPath + "/game_save/hologram_data/hologram_save.txt"))
        {
           FileStream file =  File.Open(Application.persistentDataPath + "/game_save/hologram_data/hologram_save.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), dataObjects);
            file.Close();
        }
    }
}
