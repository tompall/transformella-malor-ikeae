using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NarrativeBreakpoint : MonoBehaviour
{
    public UnityEvent OnBreakpointTriggered = new UnityEvent();

    public bool canBeTriggered = true;

    public void DisableBreakpoint()
    {
        this.canBeTriggered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MainCamera")
        {
            if (!canBeTriggered) return;

            Debug.Log("Breakpoint triggered");
            OnBreakpointTriggered.Invoke();
        }
    }
}
