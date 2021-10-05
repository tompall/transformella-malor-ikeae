using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionOnActivation : MonoBehaviour
{

    public UnityEvent OnActivate = new UnityEvent();
    private void OnEnable()
    {
        OnActivate.Invoke();
    }
}
