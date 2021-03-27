using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SilenceVideos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<VideoPlayer>().loopPointReached += EndReached;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void EndReached(VideoPlayer source)
    {
        this.GetComponent<VideoPlayer>().SetDirectAudioMute(0, true);
    }
}
