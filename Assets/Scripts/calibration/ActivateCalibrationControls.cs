using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCalibrationControls : MonoBehaviour
{
    public GameObject[] controlHandleObjects;
    public ObjectManipulator[] manipulatorComponents;
    public MeshRenderer[] rendererComponents;


    public void Start()
    {
        ActivateControls(false);
    }
    public void ActivateControls(bool state)
    {
        if (controlHandleObjects != null)
        {
            foreach (GameObject go in controlHandleObjects)
            {
                go.SetActive(state);
            }
        }
        if (manipulatorComponents != null)
        {
            foreach (ObjectManipulator om in manipulatorComponents)
            {
                om.enabled = state;
            }
        }
        if (rendererComponents != null)
        {
            foreach (MeshRenderer mr in rendererComponents)
            {
                mr.enabled = state;
            }
        }
    }
}
