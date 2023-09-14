using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TurnOffVideo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<VideoPlayer>().loopPointReached += EndReached;

    }

    private void EndReached(VideoPlayer source)
    {
        gameObject.SetActive(false);
    }
}
