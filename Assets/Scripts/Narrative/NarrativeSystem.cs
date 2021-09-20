using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NarrativeSystem : MonoBehaviour
{
    public List<NarrativeTrigger> narrativeAtoms = new List<NarrativeTrigger>();
    public NarrativeVisualGuide visualGuide;

    public NarrativeTrigger activeTrigger;

    private void Awake()
    {
        int index = 0;
        foreach(var a in narrativeAtoms)
        {
            var nextIndex = index + 1;

            if (nextIndex < narrativeAtoms.Count)
            {
                var moveVisualAction = new UnityAction(() =>
                {
                    print("moveAction");

                    StartCoroutine(visualGuide.MoveTo(narrativeAtoms[nextIndex].visualGuideTarget.position));
                });

                a.OnPlayerEnter.AddListener(() =>
                {
                    activeTrigger = a;
                });

                a.OnAudioFinished.AddListener(moveVisualAction);
            }

            index++;
        }
    }

    private void Start()
    {
        StartNarrative();
    }

    private void StartNarrative()
    {
        StartCoroutine(visualGuide.MoveTo(narrativeAtoms[0].visualGuideTarget.position));
    }
}
