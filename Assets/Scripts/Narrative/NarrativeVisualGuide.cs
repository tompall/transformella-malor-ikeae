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

    public float yOffset = -0.5f;

    public IEnumerator MoveTo(Transform target, NarrativeTrigger targetAtom, NarrativeTrigger nextAtom, float delayBefore = 0, float delayAfter = 0, bool toFloor = true)
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
    
            if(toFloor)
                tPos.y = yOffset;

            transform.position = Vector3.LerpUnclamped(startPosition, tPos, curvePercent);
            yield return null;
        }
        //transform.position = tPos;


        if (targetAtom.playAudioOnTrigger && !targetAtom.playAudio)
        {
            targetAtom.gameObject.SetActive(true);
        }

        yield return new WaitForSecondsRealtime(delayAfter);


        isMoving = false;

    }
}
