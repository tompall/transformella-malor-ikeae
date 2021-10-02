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
            Debug.Log("Waiting for audio or trigger " + target.gameObject.name);
            StopAllCoroutines();
            yield break;
        }
        else
        {
            if (target.nextTrigger != null)
            {
                MoveToNext(target.nextTrigger);
            }
        }    
    }
}
