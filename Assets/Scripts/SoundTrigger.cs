using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundTrigger : MonoBehaviour
{

    public AudioMixerSnapshot beginningSnapshot;

    public AudioMixerSnapshot triggeredSnapshot;

    // Start is called before the first frame update
    void Start()
    {
        PlayOverallSound();
    }

    private void OnTriggerEnter(Collider other)
    {

        PlaySpecificSound();
    }

    private void OnTriggerExit(Collider other)
    {
        PlayOverallSound();
    }
    public void PlaySpecificSound()
    {
        AudioTransitionToSnapshot.TransitionToSnapshot(triggeredSnapshot, 2);
    }

    public void PlayOverallSound()
    {
            AudioTransitionToSnapshot.TransitionToSnapshot(beginningSnapshot, 2);
    }
    
}
