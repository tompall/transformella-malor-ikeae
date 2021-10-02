using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NOrb : MonoBehaviour
{
    public void MoveToNext(NTrigger target)
    {
        StartCoroutine(moveNext(target));
    }

    public IEnumerator moveNext(NTrigger target)
    {
        float elapsedTime = 0;
        float duration = target.durationOfOrb;
        var currentPos = transform.position;

        if (!target.isAudioTrigger)
        {
            target.gameObject.SetActive(true);
        }

        if (!target.waitForAudio && !target.waitForTrigger)
        {
            target.isActive = true;
        }

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(currentPos, target.orbLocation.position, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return 0;
        }

        if (target.waitForAudio || target.waitForTrigger || target.isAudioTrigger)
        {
            Debug.Log("Waiting for audio or trigger");
            yield break;
        }

        if (target.nextTrigger != null)
        {
            StartCoroutine(moveNext(target.nextTrigger));
        }
    }
}
