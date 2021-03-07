using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCalibrationControls : MonoBehaviour
{
    public GameObject[] controlHandleObjects;
    public ObjectManipulator manipulatorComponent;
    public void ActivateControls(bool state)
    {
        if (controlHandleObjects != null)
        {
            foreach (GameObject go in controlHandleObjects)
            {
                go.SetActive(state);
            }
        }
        if (manipulatorComponent != null)
        {
            manipulatorComponent.enabled = state;
        }
    }
}
