using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public VideoPlayer player;
    private void Start()
    {
        player = GetComponent<VideoPlayer>();
    }
    public void PlayVideoTrigger()
    {
        player.Play();
    }
}
