using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoTriggerEntrance : MonoBehaviour
{

    public GameObject[] videoArray;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject vid in videoArray)
        {
            vid.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        foreach (GameObject vid in videoArray)
        {
            vid.SetActive(true);
        }
    }
}
