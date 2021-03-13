using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitchTrigger : MonoBehaviour
{

    public bool playerInWombRoom;

    public GameObject[] shrineWolrd;

    public GameObject[] wombWorld;
    // Start is called before the first frame update

    public static RoomSwitchTrigger instance;

    void Start()
    {
        instance = this;
    }

    public void OnTriggerEnter(Collider other)
    {

     
    }

    public void SwitchRooms()
    {

        if (playerInWombRoom)
        {
            foreach (GameObject go in wombWorld)
            {
                go.SetActive(false);
            }
            foreach (GameObject gob in shrineWolrd)
            {
                gob.SetActive(true);
            }
        }
        else if (!playerInWombRoom)
        {
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
}
