﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IkealityItem : MonoBehaviour
{
 //   public ParticleSystem particles;
    public GameObject lineObject;
    public ActivateTrail trailActivator;
    public bool lineActivated;
    public GameObject ikealityItemComponentParent;

    public void Start()
    {
        lineActivated = false;
        //   particles.enableEmission = false;
        //lineObject.SetActive(false);
        trailActivator.ActivateTrailAction();
        ikealityItemComponentParent.SetActive(true);
       // SetAllArtifacts(ikealityItemComponentParent.transform, false);
    }

    public void SetAllArtifacts(Transform transform, bool value)
    {
        foreach (Transform child in ikealityItemComponentParent.transform)
        {
            child.gameObject.SetActive(value);

        }
    }
}
