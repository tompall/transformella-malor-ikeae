using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateIkeality : MonoBehaviour
{
    public float activationTimeTarget = 2f;
    private float activationTimer;

    // private bool gazeAtIkeality;

    private GameObject currentGazeTargetObject;
    private GameObject previousGazeTargetObject;
    private GameObject previousGazedIkeality;
    private GameObject previousGazedIkealityComponent;


    public static ActivateIkeality instance;


    private void Awake()
    {
        instance = this;
    }
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

        //   Debug.Log(activationTimer);

        if (currentGazeTargetObject != null && currentGazeTargetObject.tag == "ikeality")
        {
            //  Debug.Log(currentGazeTargetObject.name);
            previousGazedIkeality = currentGazeTargetObject;

            if (currentGazeTargetObject.name == previousGazeTargetObject.name && currentGazeTargetObject.GetComponent<IkealityItem>().lineActivated == false)
            {
             //   currentGazeTargetObject.GetComponent<IkealityItem>().particles.enableEmission = true;

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
              //  previousGazedIkeality.GetComponent<IkealityItem>().particles.enableEmission = false;
            }
        }
        else if (currentGazeTargetObject != null && currentGazeTargetObject.tag == "ikealitycomponent")
        {
            Debug.Log(currentGazeTargetObject.name);

            previousGazedIkealityComponent = currentGazeTargetObject;

            if (currentGazeTargetObject.name == previousGazeTargetObject.name && currentGazeTargetObject.GetComponent<IkealityItemComponent>().circleActivated == false)
            {
               // currentGazeTargetObject.GetComponent<IkealityItemComponent>().particles.enableEmission = true;

                activationTimer -= Time.deltaTime;

                if (activationTimer <= 0)
                {
                    ActivateCircle();
                }
            }
            else
            {
                //  gazeAtIkeality = false;
                activationTimer = activationTimeTarget;
             //   previousGazedIkealityComponent.GetComponent<IkealityItemComponent>().particles.enableEmission = false;
            }

        }
        else
        {
            // gazeAtIkeality = false;
            activationTimer = activationTimeTarget;
            if (previousGazedIkeality != null)
            {
             //   previousGazedIkeality.GetComponent<IkealityItem>().particles.enableEmission = false;
            }
            if (previousGazedIkealityComponent)
            {
             //   previousGazedIkealityComponent.GetComponent<IkealityItemComponent>().particles.enableEmission = false;
            }
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


    void ActivateCircle()
    {

        IkealityItemComponent currentIkealityItemComponent = currentGazeTargetObject.GetComponent<IkealityItemComponent>();
        currentIkealityItemComponent.circleActivated = true;
        currentIkealityItemComponent.ActivateAllCircles();
        currentIkealityItemComponent.circleToActivate.SetActive(true);
        activationTimer = activationTimeTarget;
    }
    void ActivateLine()
    {
        IkealityItem currentIkealityItem = currentGazeTargetObject.GetComponent<IkealityItem>();
        currentIkealityItem.lineActivated = true;
        currentIkealityItem.lineObject.SetActive(true);
        currentIkealityItem.lineObject.GetComponent<Animator>().SetBool("start", true);
        currentIkealityItem.trailActivator.ActivateTrailAction();
        currentIkealityItem.SetAllArtifacts(currentIkealityItem.ikealityItemComponentParent.transform, true);
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
