using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReplace : MonoBehaviour
{
    public GameObject toReplace;
    public GameObject replaceWith;


    public void Start()
    {
        toReplace.SetActive(true);
        replaceWith.SetActive(false);
    }
    public void ReplaceObjects()
    {
        toReplace.SetActive(false);
        replaceWith.SetActive(true);
    }
}
