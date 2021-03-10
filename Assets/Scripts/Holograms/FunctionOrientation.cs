using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionOrientation : MonoBehaviour
{
    public GameObject menu; // Get a reference to the menu gameobject


    // Start is called before the first frame update
    void Start()
    {
        menu = this.gameObject;

       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 devicePosition = Camera.main.transform.position;

        menu.transform.position = new Vector3(devicePosition.x, devicePosition.y, devicePosition.z + 2.5f);

        Vector3 gazeDirection = Camera.main.transform.forward;

        menu.transform.rotation =  Quaternion.LookRotation(gazeDirection)* Quaternion.Euler(0, 90, 0);
    }
}
