using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class mVideoPlayerController : MonoBehaviour
{
    public VideoPlayer player;

    public void ToggleVideo()
    {
        if (player.isPlaying)
        {
            player.Pause();
        }
        else
        {
            player.Play();
        }
    }
}
