using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrail : MonoBehaviour
{
    // Start is called before the first frame update

   
    void Start()
    {
        if (gameObject.GetComponent<TrailRenderer>() != null)
        {
            gameObject.GetComponent<TrailRenderer>().enabled = false;
        }
        Invoke("ActivateTrailAction", 0.1f);
    }

   void ActivateTrailAction()
    {
        if (gameObject.GetComponent<TrailRenderer>() != null)
        {
            gameObject.GetComponent<TrailRenderer>().enabled = true;
        }
    }
}
