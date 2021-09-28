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

        Vector3 startPosition = transform.position;

        float journey = 0f;

        duration = Vector3.Distance(transform.position, target.position) / speed;

        while (journey <= duration)
        {
            journey = journey + Time.deltaTime;

            float percent = Mathf.Clamp01(journey / duration);

            float curvePercent = animationCurve.Evaluate(percent);

            transform.position = Vector3.LerpUnclamped(startPosition, target.position, curvePercent);
            yield return null;
        }
        transform.position = target.position;

        yield return new WaitForSecondsRealtime(delayAfter);
        nextAtom.gameObject.SetActive(true);
    }
}
