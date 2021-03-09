using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectTriggerEntrance : MonoBehaviour
{

    public GameObject[] objectsToActivate;
    public GameObject[] objectsToDeactivate;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (objectsToActivate != null)
        {

            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
            }
        }

        if (objectsToDeactivate != null)
        {

            foreach (GameObject ob in objectsToDeactivate)
            {
                ob.SetActive(false);
            }
        }
    }
}
