using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NarrativeVisualGuide : MonoBehaviour
{
    public AnimationCurve animationCurve;
    private float duration = 3f;
    public float speed = 10f;

    private bool isMoving = false;

    public Transform target;
    
    public int round = 0;

    public IEnumerator MoveTo(Transform target, NarrativeTrigger targetAtom, NarrativeTrigger nextAtom, float delayBefore = 0, float delayAfter = 0)
    {
        isMoving = true;

        print("moveAction by: Trigger " + targetAtom.nID);

        yield return new WaitForSecondsRealtime(delayBefore);

        Vector3 startPosition = transform.position;

        float journey = 0f;

        duration = Vector3.Distance(transform.position, target.position) / speed;

        var tPos = Vector3.zero;


        while (journey <= duration)
        {
            journey = journey + Time.deltaTime;

            float percent = Mathf.Clamp01(journey / duration);

            float curvePercent = animationCurve.Evaluate(percent);

            tPos = target.position;

            tPos.y = -0.9f;

            transform.position = Vector3.LerpUnclamped(startPosition, tPos, curvePercent);
            yield return null;
        }
        //transform.position = tPos;

        if (targetAtom.playAudioOnTrigger)
            targetAtom.gameObject.SetActive(true);

        isMoving = false;

        yield return new WaitForSecondsRealtime(delayAfter);
    }

    public void RunSequence(NarrativeTrigger nt)
    {
        //StartCoroutine(StartSequence(nt, 0));
    }

    public IEnumerator StartSequence(NarrativeTrigger nt, int nextIndex )
    {
        if (nt.sequence.Count < nextIndex) yield break;

        var target = nt.sequence[nextIndex];

        Vector3 startPosition = transform.position;

        float journey = 0f;

        duration = Vector3.Distance(transform.position, target.position) / speed;

        var tPos = Vector3.zero;

        while (journey <= duration)
        {
            journey = journey + Time.deltaTime;

            float percent = Mathf.Clamp01(journey / duration);

            float curvePercent = animationCurve.Evaluate(percent);

            tPos = target.position;

            tPos.y = -0.9f;

            transform.position = Vector3.LerpUnclamped(startPosition, tPos, curvePercent);
            yield return null;
        }

        StartCoroutine(StartSequence(nt, nextIndex + 1));
    }
}
