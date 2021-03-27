using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectActivator : MonoBehaviour
{

    public GameObject[] objectsToActivate;

    public GameObject[] objectsToDeactivate;

    private GameObject currentGazeTargetObject;

    public bool gazeActivated;

    public float activationTimeTarget = 5f;
    private float activationTimer;

    // Start is called before the first frame update
    void Start()
    {
        gazeActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentGazeTargetObject = CoreServices.InputSystem.GazeProvider.GazeTarget;
       


        //   Debug.Log(activationTimer);

        if (currentGazeTargetObject != null && currentGazeTargetObject.tag == "activator" )
        {
            //  Debug.Log(currentGazeTargetObject.name);


            if (!gazeActivated && currentGazeTargetObject.name == this.gameObject.name)
            {


                activationTimer -= Time.deltaTime;

                if (activationTimer <= 0)
                {
                    Debug.Log(objectsToActivate.Length);

                    gazeActivated = true;
                    if (objectsToActivate != null)
                    {
                        foreach (GameObject go in objectsToActivate)
                        {
                            go.SetActive(true);

                        }
                    }
                    if (this.gameObject.GetComponent<EnableVideosLines>() != null)
                    {
                        this.gameObject.GetComponent<EnableVideosLines>().StartVideos();
                        this.gameObject.GetComponent<EnableVideosLines>().StopVideos();
                    }
                }
            }
            else
            {
                activationTimer = activationTimeTarget;
            }
        }
      
        else
        {
            
            activationTimer = activationTimeTarget;
        }
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
