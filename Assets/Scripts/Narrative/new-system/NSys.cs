using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NSys : MonoBehaviour
{
    public NOrb orb;
    public List<NTrigger> triggers = new List<NTrigger>();

    private void Awake()
    {
        int index = 0;
        foreach(var t in triggers)
        {
            t.gameObject.SetActive(false);

            if (index + 1 < triggers.Count)
            {
                t.nextTrigger = triggers[index + 1];
                index++;

                if (t.isAudioTrigger && !t.waitForTrigger)
                {
                    //t.OnAudioFinished.AddListener(() => { StartCoroutine(orb.moveNext(t.nextTrigger)); });
                }

                if (t.waitForTrigger)
                {
                    t.OnTriggerEntered.AddListener(() => { StartCoroutine(orb.moveNext(t.nextTrigger)); });
                }
            }
        }
    }

    public void StartNarrative()
    {
        triggers[0].gameObject.SetActive(true);
    }
}
