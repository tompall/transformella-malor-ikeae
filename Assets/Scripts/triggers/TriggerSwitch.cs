using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSwitch : MonoBehaviour
{
    public List<GameObject> switchables = new List<GameObject>();
    public GameObject target;

    public List<GameObject> objectsToActivate = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        foreach(var s in switchables)
        {
            if(s == target)
            {
                s.SetActive(true);

                foreach(var obj in objectsToActivate)
                {
                    obj.SetActive(true);
                }
            }
            else
            {
                s.SetActive(false);
            }
        }
    }

}
