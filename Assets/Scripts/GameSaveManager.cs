using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Newtonsoft.Json;

public class GameSaveManager : MonoBehaviour
{

    private string jsonPath = "/game_save/hologram_save.json";
    public List<HologramItemData> dataObjects;

    public SaveItems si = new SaveItems();

    public void Awake()
    {
       si.SetHologramitems(dataObjects);

        LoadGame();

    }

    public void Start()
    {
      
    }

    public void Update()
    {
        
    }

    public bool IsSaveFile()
    {
        return Directory.Exists(Application.persistentDataPath + "/game_save");
    }

    public bool DoesFileExists()
    {
        return IsSaveFile() && File.Exists(Application.persistentDataPath + jsonPath);
    }

    public void LoadGame()
    {
        if (DoesFileExists())
        {
            string path = Application.persistentDataPath + jsonPath;
            byte[] data = UnityEngine.Windows.File.ReadAllBytes(path);
            string json = Encoding.ASCII.GetString(data);

            var convertedJson = JsonConvert.DeserializeObject<SaveItems>(json);
            si.SetHologramitems(convertedJson.GetHologramitems());
            Debug.Log("LOADING: " + si.hologramItems[0].localPosY);

            for (int i = 0; i < si.GetHologramitems().Count; i++)
            {
                dataObjects[i].localPosX = si.GetHologramitems()[i].localPosX;
                dataObjects[i].localPosY = si.GetHologramitems()[i].localPosY;
                dataObjects[i].localPosZ = si.GetHologramitems()[i].localPosZ;

                dataObjects[i].localRotx = si.GetHologramitems()[i].localRotx;
                dataObjects[i].localRoty = si.GetHologramitems()[i].localRoty;
                dataObjects[i].localRotz = si.GetHologramitems()[i].localRotz;

                dataObjects[i].localSx = si.GetHologramitems()[i].localSx;
                dataObjects[i].localSy = si.GetHologramitems()[i].localSy;
                dataObjects[i].localSz = si.GetHologramitems()[i].localSz;
            }

            //dataObjects = si.GetHologramitems();
            Debug.Log("LOADING dataObjects: " + dataObjects[0].localPosY);
        }
 
    }

    public void SaveGame()
    {
        if (!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save");
        }

        string path = Application.persistentDataPath + "/game_save/hologram_save.json";
        si.SetHologramitems(dataObjects);
        Debug.Log("SAVING dataObjects: " + dataObjects[0].localPosY);
        string json = JsonConvert.SerializeObject(si);
        byte[] data = Encoding.ASCII.GetBytes(json);

        UnityEngine.Windows.File.WriteAllBytes(path, data);
    }
}
