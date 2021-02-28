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
        
    }
    public void ActivateTrailAction()
    {
        StartCoroutine(ActivateTrailTimer());
    }

   public IEnumerator ActivateTrailTimer()
    {
        yield return new WaitForSeconds (0.8f);
        if (gameObject.GetComponent<TrailRenderer>() != null)
        {
            gameObject.GetComponent<TrailRenderer>().enabled = true;
        }
    }
}
