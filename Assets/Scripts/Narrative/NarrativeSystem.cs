using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NarrativeSystem : MonoBehaviour
{
    public List<NarrativeTrigger> narrativeAtoms = new List<NarrativeTrigger>();
    public NarrativeVisualGuide visualGuide;

    public NarrativeTrigger activeTrigger;

    public LineRenderer line;

    public GameObject startAnnotation;

    public float lineUpdateCounter = 0;

    public float lineUpdateFrequency = 1f;

    private bool canUpdateLine = false;

    private void Awake()
    {
        int index = 0;
        foreach(var atom in narrativeAtoms)
        {
            atom.nID = index;

            var nextIndex = index + 1;

            atom.gameObject.SetActive(false);

            if (nextIndex < narrativeAtoms.Count)
            {
                var moveVisualAction = new UnityAction(() =>
                {
                    print("moveAction");
                    
                    var next = narrativeAtoms[nextIndex];

                    StartCoroutine(visualGuide.MoveTo(next.visualGuideTarget, next, next.delayBefore, next.delayAfter));
                });

                atom.OnPlayerEnter.AddListener(() =>
                {
                    activeTrigger = atom;
                });

                atom.OnMoveNext.AddListener(moveVisualAction);
            }

            index++;
        }

    }

    private void Start()
    {
        //StartNarrative();
        visualGuide.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!canUpdateLine) return;
        
        if(lineUpdateCounter >= lineUpdateFrequency)
        {
            DrawGuideLine();
            lineUpdateCounter = 0;
            print("updating line");
        }

        lineUpdateCounter += Time.deltaTime;
    }

    private void DrawGuideLine()
    {
        line.positionCount = narrativeAtoms.Count;

        var yOffset = -1f;

        var linePos = Vector3.one;

        int index = 0;
        foreach(var atom in narrativeAtoms)
        {
            linePos = atom.visualGuideTarget.position;

            linePos.y = yOffset;
            line.SetPosition(index, linePos);
            index++;
        }
    }

    public void StartNarrative()
    {
        startAnnotation.SetActive(false);
        narrativeAtoms[0].gameObject.SetActive(true);
        visualGuide.gameObject.SetActive(true);
        DrawGuideLine();
        canUpdateLine = true;
        StartCoroutine(visualGuide.MoveTo(narrativeAtoms[0].visualGuideTarget, narrativeAtoms[1], narrativeAtoms[0].delayBefore, narrativeAtoms[0].delayAfter));
    }
}
