using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTransitionToSnapshot : MonoBehaviour
{

   public static void TransitionToSnapshot(AudioMixerSnapshot snapshot, float time)
    {
        snapshot.TransitionTo(time);
    }
}
