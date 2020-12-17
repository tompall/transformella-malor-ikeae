using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHeadGaze : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward,out hitInfo, 20.0f))
        {
            Debug.Log(hitInfo.collider.gameObject.name);
            if (hitInfo.collider.gameObject.tag == "sounditem")
            {
                hitInfo.collider.gameObject.GetComponent<SoundTrigger>().PlaySpecificSound();
            }
            else
            {
                
                hitInfo.collider.gameObject.GetComponent<SoundTrigger>().PlayOverallSound();
            }
        }
        
    }
}
