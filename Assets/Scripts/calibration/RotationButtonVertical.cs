using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationButtonVertical : MonoBehaviour
{

    public float rotationSpeed;
    public bool isUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRotateGameObject( GameObject go)
    {
        Debug.Log("start");
        StartCoroutine(RotateObjectX(rotationSpeed, go));
    }

    public void StopRotateGameObject()
    {
        Debug.Log("stop");
        StopAllCoroutines();
    }

    public IEnumerator RotateObjectX(float duration, GameObject go)
    {
        float startRotation = go.transform.eulerAngles.x;
        float endRotation = startRotation;
        if (isUp)
        {
            endRotation = startRotation + 360.0f;
        }
        else if (!isUp)
        {
            endRotation = startRotation - 360.0f;
        }
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float xRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            go.transform.eulerAngles = new Vector3(xRotation, go.transform.eulerAngles.y,
            go.transform.eulerAngles.z);
            yield return null;
        }
    }

    
}
