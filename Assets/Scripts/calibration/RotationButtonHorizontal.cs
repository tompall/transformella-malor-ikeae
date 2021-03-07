using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationButtonHorizontal : MonoBehaviour
{

    public float rotationSpeed;
    public bool isright;
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
        StartCoroutine(RotateObjectY(rotationSpeed, go));
    }

    public void StopRotateGameObject()
    {
        Debug.Log("stop");
        StopAllCoroutines();
    }

    public IEnumerator RotateObjectY(float duration, GameObject go)
    {
        float startRotation = go.transform.eulerAngles.y;
        float endRotation = startRotation;
        if (isright)
        {
            endRotation = startRotation - 360.0f;
        }
        else if (!isright)
        {
            endRotation = startRotation + 360.0f;
        }
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            go.transform.eulerAngles = new Vector3(go.transform.eulerAngles.x, yRotation,
            go.transform.eulerAngles.z);
            yield return null;
        }
    }

   
}
