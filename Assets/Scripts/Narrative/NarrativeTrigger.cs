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
    public float delayBefore = 1f;
    public float delayAfter = 1f;

    [SerializeField]
    private bool playAudio = true;

    [SerializeField]
    private bool deactivateOnExit = true;

    public UnityEvent OnPlayerEnter = new UnityEvent();
    public UnityEvent OnPlayerExit = new UnityEvent();

    public UnityEvent OnMoveNext = new UnityEvent();


    private bool isActive = false;

    private bool deactivated = false;
    private void Update()
    {
        if (!isActive) return;

        if (audioSource.isPlaying) return;

        isActive = false;
        
        OnMoveNext.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (deactivated) return;

        if (other.tag == "Player" || other.tag == "MainCamera")
        {
            isActive = true;
            Debug.Log("Player entered: " + nID);

            OnPlayerEnter.Invoke();


            //if should play audio, play
            if (!audioSource.isPlaying && playAudio)
                audioSource.Play();
            else
                //if shouldnt play audio, trigger delayed MoveNext event
                StartCoroutine(TriggerMoveNextWithoutAudio());
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
            OnMoveNext.Invoke();

            if(deactivateOnExit)
                deactivated = true;
        }
    }

    private IEnumerator TriggerMoveNextWithoutAudio()
    {
        yield return new WaitForSecondsRealtime(delayBefore);
        OnMoveNext.Invoke();
    }
}
