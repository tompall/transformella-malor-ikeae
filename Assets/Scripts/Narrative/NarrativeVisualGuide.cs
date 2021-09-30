using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NarrativeVisualGuide : MonoBehaviour
{
    public AnimationCurve animationCurve;
    private float duration = 3f;
    public float speed = 10f;
    public IEnumerator MoveTo(Transform target, NarrativeTrigger nextAtom, float delayBefore = 0, float delayAfter = 0)
    {
        yield return new WaitForSecondsRealtime(delayBefore);

        nextAtom.gameObject.SetActive(true);

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
        transform.position = tPos;

        yield return new WaitForSecondsRealtime(delayAfter);
    }
}
