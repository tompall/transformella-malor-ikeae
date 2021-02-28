using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateIkeality : MonoBehaviour
{
    public float activationTimeTarget = 5f;
    private float activationTimer;

    // private bool gazeAtIkeality;

    private GameObject currentGazeTargetObject;
    private GameObject previousGazeTargetObject;
    private GameObject previousGazedIkeality;

    // Start is called before the first frame update
    void Start()
    {
        activationTimer = activationTimeTarget;
    }

    // Update is called once per frame
    void Update()
    {

        currentGazeTargetObject = CoreServices.InputSystem.GazeProvider.GazeTarget;

        previousGazeTargetObject = currentGazeTargetObject;

        Debug.Log(activationTimer);

        if (currentGazeTargetObject != null && currentGazeTargetObject.tag == "ikeality")
        {
            previousGazedIkeality = currentGazeTargetObject;

            if (currentGazeTargetObject.name == previousGazeTargetObject.name && currentGazeTargetObject.GetComponent<IkealityItem>().lineActivated == false)
            {
                currentGazeTargetObject.GetComponent<IkealityItem>().particles.enableEmission = true;

                activationTimer -= Time.deltaTime;

                if (activationTimer <= 0)
                {
                     ActivateLine();
                }

            }
            else
            {
                //  gazeAtIkeality = false;
                activationTimer = activationTimeTarget;
                previousGazedIkeality.GetComponent<IkealityItem>().particles.enableEmission = false;
            }
        }
        else
        {
            // gazeAtIkeality = false;
            activationTimer = activationTimeTarget;
            previousGazedIkeality.GetComponent<IkealityItem>().particles.enableEmission = false;
        }
        /*RaycastHit hitInfo;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, 20.0f))
        {
            Debug.Log(hitInfo.collider.gameObject.name);
          //  if (hitInfo.collider.gameObject.tag == "ikeality")
           // {
            //    Debug.Log(hitInfo.transform.gameObject.name);
          //  }

        }*/
        //  LogCurrentGazeTarget();
    }



    void ActivateLine()
    {
        currentGazeTargetObject.GetComponent<IkealityItem>().lineActivated = true;
        currentGazeTargetObject.GetComponent<IkealityItem>().lineObject.SetActive(true);
        activationTimer = activationTimeTarget;
    }

    void LogCurrentGazeTarget()
    {
        if (CoreServices.InputSystem.GazeProvider.GazeTarget)
        {
            Debug.Log("User gaze is currently over game object: "
                + CoreServices.InputSystem.GazeProvider.GazeTarget);
        }
    }
}
