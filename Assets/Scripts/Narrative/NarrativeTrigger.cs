using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class NarrativeTrigger : MonoBehaviour
{
    public int nID;

    public AudioSource audioSource;
    public Transform visualGuideTarget;

    public UnityEvent OnPlayerEnter = new UnityEvent();
    public UnityEvent OnPlayerExit = new UnityEvent();

    public UnityEvent OnAudioFinished = new UnityEvent();

    private bool isActive = false;

    private bool deactivated = false;
    private void Update()
    {
        if (!isActive) return;

        if (audioSource.isPlaying) return;

        isActive = false;
        
        OnAudioFinished.Invoke();

        deactivated = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (deactivated) return;

        if (other.tag == "Player" || other.tag == "MainCamera")
        {
            isActive = true;
            Debug.Log("Player entered: " + nID);

            OnPlayerEnter.Invoke();

            if(!audioSource.isPlaying)
                audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (deactivated) return;

        if (other.tag == "Player" || other.tag == "MainCamera")
        {
            isActive = false;

            Debug.Log("Player left: " + nID);
            audioSource.Stop();

            OnPlayerExit.Invoke();

            deactivated = true;
        }
    }
}
