using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NarrativeBreakpoint : MonoBehaviour
{
    public UnityEvent OnBreakpointTriggered = new UnityEvent();
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MainCamera")
        {
            Debug.Log("Breakpoint triggered");
            OnBreakpointTriggered.Invoke();
        }
    }
}
