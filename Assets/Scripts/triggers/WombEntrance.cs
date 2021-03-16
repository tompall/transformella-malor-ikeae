using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WombEntrance : MonoBehaviour
{


    public GameObject[] shrineWolrd;

    public GameObject[] wombWorld;

    public void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        RoomSwitchTrigger.instance.playerInWombRoom = true;

            foreach (GameObject go in wombWorld)
            {
                go.SetActive(true);
            }
            foreach (GameObject gob in shrineWolrd)
            {
                gob.SetActive(false);
            }
        
    }
}
