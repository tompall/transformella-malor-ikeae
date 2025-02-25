﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class NarrativeSystem : MonoBehaviour
{
    public List<NarrativeTrigger> narrativeAtoms = new List<NarrativeTrigger>();
    public NarrativeVisualGuide visualGuide;

    public NarrativeTrigger activeTrigger;

    public LineRenderer line;

    public GameObject startAnnotation;

    public Color activeLineColor;
    public Color inactiveLineColor;

    public float lineGradientOffset = 0.15f;

    public float lineUpdateCounter = 0;

    public float lineUpdateFrequency = 1f;

    public float lineStartWombroom = 0.65f;

    private bool canUpdateLine = false;

    private float totalNarrativePoints;

    public static NarrativeSystem instance;

    private void Awake()
    {
        instance = this;
        int index = 0;
        totalNarrativePoints = narrativeAtoms.Count;
        foreach(var atom in narrativeAtoms)
        {
            atom.nID = index;

            var nextIndex = index + 1;

            atom.gameObject.SetActive(false);

            atom.SetAnnotation("Narrative Atom " + atom.nID);

            if (nextIndex < narrativeAtoms.Count)
            {
                var next = narrativeAtoms[nextIndex];

                var moveVisualAction = new UnityAction(() =>
                {
                    visualGuide.speed = next.speedOfOrb;

                    if(nextIndex+1 < narrativeAtoms.Count)
                        StartCoroutine(visualGuide.MoveTo(next.visualGuideTarget, next, narrativeAtoms[nextIndex+1], next.delayBefore, next.delayAfter));
                });

                atom.OnPlayerEnter.AddListener(() =>
                {
                    activeTrigger = atom;
                });

                //if (next.autopilot && !next.playAudio) return;

                atom.OnMoveNext.AddListener(moveVisualAction);
            }

            index++;
        }

        //float alpha = 1.0f;
        //var gradient = new Gradient();
        //gradient.SetKeys(
        //    new GradientColorKey[] { new GradientColorKey(activeLineColor, 0f), new GradientColorKey(inactiveLineColor, 1f) },
        //    new GradientAlphaKey[] { new GradientAlphaKey(0f, 0f), new GradientAlphaKey(0, 0f + 0.1f) }
        //);

        //line.colorGradient = gradient;

        //LineGradientUpdate(0);
    }

    private void LineGradientUpdate(float currentIndex)
    {
        //float currentProgress = currentIndex / totalNarrativePoints;

        //Debug.Log("Current progress of line: " + currentProgress);
        //float alpha = 1.0f;
        //var gradient = new Gradient();
        //gradient.SetKeys(
        //    new GradientColorKey[] { new GradientColorKey(activeLineColor, currentProgress + lineGradientOffset), new GradientColorKey(inactiveLineColor, currentProgress + lineGradientOffset*2) },
        //    new GradientAlphaKey[] { new GradientAlphaKey(alpha, currentProgress + 0.05f), new GradientAlphaKey(0, currentProgress + 0.1f) }
        //);

        //line.colorGradient = gradient;
    }

    private void Start()
    {
        //StartNarrative();
        visualGuide.gameObject.SetActive(false);

        line.material = new Material(Shader.Find("Sprites/Default"));
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.O))
        {
            SetLineFromWombToEnd();
        }
        if (!canUpdateLine) return;
        
        if(lineUpdateCounter >= lineUpdateFrequency)
        {
            DrawGuideLine();
            lineUpdateCounter = 0;
            //print("updating line");
        }

        lineUpdateCounter += Time.deltaTime;
    }

    public void DrawGuideLine()
    {
        canUpdateLine = true;
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

    public void SetLineFromStartToWomb()
    {
        float alpha = 1.0f;
        var gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(activeLineColor, 0f), new GradientColorKey(activeLineColor, 1f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0f), new GradientAlphaKey(alpha, lineStartWombroom), new GradientAlphaKey(0f, lineStartWombroom+ 0.01f), new GradientAlphaKey(0, 1f) }
        );

        line.colorGradient = gradient;
    }

    public void SetLineFromWombToEnd()
    {
        float alpha = 1.0f;
        var gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(activeLineColor, 0f), new GradientColorKey(activeLineColor, 1f) },
            new GradientAlphaKey[] { new GradientAlphaKey(0f, 0f), new GradientAlphaKey(0f, lineStartWombroom), new GradientAlphaKey(1f, lineStartWombroom+0.01f), new GradientAlphaKey(1, 1f) }
        );

        line.colorGradient = gradient;
    }

    public void ShowVisualGuide()
    {
        visualGuide.gameObject.SetActive(true);
    }

    public void StartNarrative()
    {
        startAnnotation.SetActive(false);
        narrativeAtoms[0].gameObject.SetActive(true);
        //StartCoroutine(visualGuide.MoveTo(narrativeAtoms[0].visualGuideTarget, narrativeAtoms[0], narrativeAtoms[0], narrativeAtoms[0].delayBefore, narrativeAtoms[0].delayAfter, false));
    }

    public void BreakNarrative(NarrativeTrigger trigger)
    {
        StopAllCoroutines();

        var tempPos = Camera.main.transform.position;

        tempPos.y = visualGuide.yOffset;

        visualGuide.transform.position = tempPos;

        var nextIndex = narrativeAtoms.IndexOf(trigger) + 1;
        trigger.gameObject.SetActive(true);
        Debug.Log("Next: " + trigger.gameObject.name + " After that: " + narrativeAtoms[nextIndex].gameObject.name);
        StartCoroutine(visualGuide.MoveTo(trigger.visualGuideTarget, narrativeAtoms[nextIndex], narrativeAtoms[nextIndex], trigger.delayBefore, trigger.delayAfter));
    }
}
