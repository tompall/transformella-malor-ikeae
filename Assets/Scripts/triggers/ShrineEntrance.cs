using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineEntrance : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject[] shrineWolrd;

    public GameObject[] wombWorld;
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        RoomSwitchTrigger.instance.playerInWombRoom = false;

        foreach (GameObject go in wombWorld)
        {
            go.SetActive(false);
        }
        foreach (GameObject gob in shrineWolrd)
        {
            gob.SetActive(true);
        }
    }
}
