using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NarrativeVisualGuide : MonoBehaviour
{
    public AnimationCurve animationCurve;
    public float duration = 3f;
    public IEnumerator MoveTo(Vector3 targetPosition, NarrativeTrigger nextAtom, float delayBefore = 0, float delayAfter = 0)
    {
        yield return new WaitForSecondsRealtime(delayBefore);

        Vector3 startPosition = transform.position;

        float journey = 0f;

        while (journey <= duration)
        {
            journey = journey + Time.deltaTime;

            float percent = Mathf.Clamp01(journey / duration);

            float curvePercent = animationCurve.Evaluate(percent);

            transform.position = Vector3.LerpUnclamped(startPosition, targetPosition, curvePercent);
            yield return null;
        }
        transform.position = targetPosition;

        yield return new WaitForSecondsRealtime(delayAfter);
        nextAtom.gameObject.SetActive(true);
    }
}
