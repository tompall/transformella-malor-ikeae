using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NOrb : MonoBehaviour
{
    public GameObject visual;
    public void MoveToNext(NTrigger target)
    {
        StartCoroutine(moveNext(target));
    }

    public IEnumerator moveNext(NTrigger target)
    {
        float elapsedTime = 0;
        float duration = target.durationOfOrb;
        var currentPos = transform.position;

        var newPos = Vector3.one;

        var targetPos = Vector3.one;

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
            targetPos = target.orbLocation.position;
            targetPos.y = -0.5f;

            newPos = Vector3.Lerp(currentPos, targetPos, (elapsedTime / duration));

            transform.position = newPos;
            
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

    public void ShowVisual(bool on)
    {
        visual.SetActive(on);
    }
}
