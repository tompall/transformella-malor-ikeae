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

    public List<Transform> sequence;

    public bool autopilot = false;

    public float delayBefore = 1f;
    public float delayAfter = 1f;

    public float speedOfOrb = 1f;

    [SerializeField]
    public bool playAudio = true;

    public bool playAudioOnTrigger = true;

    [SerializeField]
    private bool deactivateOnExit = true;   

    [SerializeField]
    private TextMesh annotation;

    public UnityEvent OnPlayerEnter = new UnityEvent();
    public UnityEvent OnPlayerExit = new UnityEvent();

    public UnityEvent OnMoveNext = new UnityEvent();

    public UnityEvent OnAudioFinished = new UnityEvent();

    private bool isActive = false;

    private bool deactivated = false;

    public bool hasBallArrived = false;

    private void OnEnable()
    {
        //if(isActive && autopilot)
        //{
        //    if (!audioSource.isPlaying && playAudio)
        //        audioSource.Play();
        //    else
        //        //if shouldnt play audio, trigger delayed MoveNext event
        //        StartCoroutine(TriggerMoveNextWithoutAudio());
        //}

        gameObject.name = "Trigger " + nID;
    }
    private void Update()
    {
        if (!isActive) return;

        if (audioSource.isPlaying) return;

        isActive = false;

        OnAudioFinished.Invoke();

        if (playAudioOnTrigger || autopilot)
        {
            Debug.Log("Update trigger");
            OnMoveNext.Invoke();
        }

        Debug.Log("Audio finished: " + gameObject.name+" > " + nID);
    }

    public void SetAnnotation(string text)
    {
        this.annotation.text = text;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("Triggerenter+ " + gameObject.name);

        if (deactivated) return;

        if (other.tag == "Player" || other.tag == "MainCamera")
        {
            isActive = true;
            Debug.Log("Player entered: " + nID);

            OnPlayerEnter.Invoke();

            if (autopilot) {
                if (!audioSource.isPlaying && playAudio)
                    audioSource.Play();
                OnMoveNext.Invoke();
                return;
            } 

            //if should play audio, play
            if (!audioSource.isPlaying && playAudio && playAudioOnTrigger)
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
            Debug.Log("Player left: " + nID);
            //audioSource.Stop();

            OnPlayerExit.Invoke();

            if(deactivateOnExit)
                deactivated = true;
        }
    }

    public IEnumerator TriggerMoveNextWithoutAudio()
    {
        yield return new WaitForSecondsRealtime(delayBefore);
        OnMoveNext.Invoke();
    }
}
