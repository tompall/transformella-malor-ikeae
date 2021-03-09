using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectTriggerEntrance : MonoBehaviour
{

    public GameObject[] objectsToActivate;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject vid in objectsToActivate)
        {
            vid.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        foreach (GameObject vid in objectsToActivate)
        {
            vid.SetActive(true);
        }
    }
}
