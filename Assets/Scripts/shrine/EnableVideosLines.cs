using Microsoft.MixedReality.Toolkit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnableVideosLines : MonoBehaviour
{

    public List<GameObject> videosToEnable;
    public List<GameObject> videosToDisable;

    public GameObject horizontalLines;

    public GameObject nextInteractiveIkeality;


    public VideoPlayer firstVideo;

    public VideoPlayer secondVideo;


    
    // Start is called before the first frame update
    public void Start()
    {
        

        if (nextInteractiveIkeality != null)
        {
            nextInteractiveIkeality.GetComponent<BoxCollider>().enabled = false;
        }

        firstVideo.loopPointReached += EndReached;


    }

    private void EndReached(VideoPlayer source)
    {
        if (firstVideo != null)
        {
            secondVideo.Play();
            secondVideo.SetDirectAudioVolume(0, 1f);
            secondVideo.gameObject.AddComponent<SilenceVideos>();

        }
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void StartVideos()
    {
        
            StartCoroutine(TurnVideosOn());
            //  Debug.Log("videoson");
        
    }

    public void StopVideos()
    {

        StartCoroutine(TurnVideosOff());

    }


    public IEnumerator TurnVideosOn()
    {
        foreach (GameObject go in videosToEnable)
        {
            go.SetActive(true);

            if (go.tag == "spawnlines")
            {
                horizontalLines.SetActive(true);
            }

            if (go.tag == "lastvideo")
            {
                if (nextInteractiveIkeality != null)
                {
                    nextInteractiveIkeality.GetComponent<BoxCollider>().enabled = true;
                }
            }


            yield return new WaitForSeconds(2f);
        }

        if (horizontalLines != null)
        {
            horizontalLines.SetActive(true);
        }


        yield return null;
    }

    public IEnumerator TurnVideosOff()
    {

        Debug.Log("videosoff");
        if (videosToDisable != null)
        {
            foreach (GameObject go in videosToDisable)
            {
                go.SetActive(false);
                yield return new WaitForSeconds(0.5f);
            }

        }
        yield return null;
    }
}
