using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableVideosLines : MonoBehaviour
{

    public List <GameObject> videosToEnable;

    public GameObject horizontalLines;

    // Start is called before the first frame update
    void Start()
    {
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            Transform child = transform.GetChild(i);
            videosToEnable.Add(child.gameObject);
        }

        StartCoroutine(TurnVideosOn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator TurnVideosOn()
    {
        foreach (GameObject go in videosToEnable)
        {
            go.SetActive(true);
            yield return new WaitForSeconds (0.5f);
        }
        horizontalLines.SetActive(true);

        StartCoroutine(TurnVideosOff());
        yield return null;
    }

    public IEnumerator TurnVideosOff()
    {

        yield return new WaitForSeconds(220f);
        foreach (GameObject go in videosToEnable)
        {
            go.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
        horizontalLines.SetActive(false);
        yield return null;
    }
}
