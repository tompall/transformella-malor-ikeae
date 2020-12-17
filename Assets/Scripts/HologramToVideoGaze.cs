using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramToVideoGaze : MonoBehaviour
{

    public GameObject video;
    public GameObject hologram;
    // Start is called before the first frame update
    void Start()
    {
        video.SetActive(false);
        hologram.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, 20.0f))
        {
            Debug.Log(hitInfo.collider.gameObject.name);
            if (hitInfo.collider.gameObject.tag == "hologram")
            {
                hologram.SetActive(false);
                video.SetActive(true);
            }
           
        }

    }
}
