using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineEntrance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        RoomSwitchTrigger.instance.playerInWombRoom = false;

        foreach (GameObject go in RoomSwitchTrigger.instance.wombWorld)
        {
            go.SetActive(false);
        }
        foreach (GameObject gob in RoomSwitchTrigger.instance.shrineWolrd)
        {
            gob.SetActive(true);
        }
    }
}
