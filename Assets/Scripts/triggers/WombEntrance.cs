using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WombEntrance : MonoBehaviour
{

    public void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        RoomSwitchTrigger.instance.playerInWombRoom = true;

            foreach (GameObject go in RoomSwitchTrigger.instance.wombWorld)
            {
                go.SetActive(true);
            }
            foreach (GameObject gob in RoomSwitchTrigger.instance.shrineWolrd)
            {
                gob.SetActive(false);
            }
        
    }
}
