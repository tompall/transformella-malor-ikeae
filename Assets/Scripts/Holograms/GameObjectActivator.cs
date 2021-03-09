using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectActivator : MonoBehaviour
{

    public GameObject[] objectsToActivate;

    public GameObject[] objectsToDeactivate;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateGameObjects()
    {
        if (objectsToActivate != null)
        {
            foreach (GameObject go in objectsToActivate)
            {
                go.SetActive(true);
            }
        }
    }

    public void DeactivateGameObjects()
    {
        if (objectsToDeactivate != null)
        {
            foreach (GameObject go in objectsToDeactivate)
            {
                go.SetActive(false);
            }
        }
    }
}
