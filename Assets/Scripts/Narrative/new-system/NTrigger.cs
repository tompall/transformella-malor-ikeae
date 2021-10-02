using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NTrigger : MonoBehaviour
{
    public NTrigger nextTrigger;

    public AudioSource audioSource;

    public Transform orbLocation;

    public float durationOfOrb = 5f;

    public bool isAudioTrigger = false;

    public bool isActive = false;

    public bool waitForAudio = false;
    public bool waitForTrigger = false;

    public UnityEvent OnAudioFinished = new UnityEvent();
    public UnityEvent OnTriggerEntered = new UnityEvent();

    public bool firstFrame = true;


    private void OnEnable()
    {
        if (!isAudioTrigger) return;

        if (waitForTrigger)
        {
            OnTriggerEntered.Invoke();
            Debug.Log("Trigger enter invoked: " + gameObject.name);
        }

        isActive = true;
        audioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag != "MainCamera") return;
        //if (!isAudioTrigger) return;

        //if (waitForTrigger)
        //{
        //    OnTriggerEntered.Invoke();
        //}

        //isActive = true;
        //audioSource.Play();
    }

    private void Update()
    {
        if (!isAudioTrigger || !isActive) return;

        if (audioSource.isPlaying) return;

        OnAudioFinished.Invoke();

        isActive = false;

        Debug.Log("Audio finished");
    }
}
