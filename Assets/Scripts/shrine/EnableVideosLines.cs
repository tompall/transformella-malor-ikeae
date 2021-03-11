using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableVideosLines : MonoBehaviour
{

    public List <GameObject> videosToEnable;

    public GameObject horizontalLines;

    // Start is called before the first frame update
    public void Start()
    {

         

       /* foreach (GameObject go in videosToEnable)
        {
            go.SetActive(true);
           
        }
        horizontalLines.SetActive(true);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartVideos()
    {
        StartCoroutine(TurnVideosOn());
    }


    public IEnumerator TurnVideosOn()
    {
        foreach (GameObject go in videosToEnable)
        {
            go.SetActive(true);
            yield return new WaitForSeconds (0.5f);
        }
        horizontalLines.SetActive(true);

       // StartCoroutine(TurnVideosOff());
      //  yield return null;
    }

    public IEnumerator TurnVideosOff()
    {

       // yield return new WaitForSeconds(220f);
        foreach (GameObject go in videosToEnable)
        {
            go.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
        horizontalLines.SetActive(false);
        yield return null;
    }
}
