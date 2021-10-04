using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NSys : MonoBehaviour
{
#region NARRATIVE VARIABLES
    public NOrb visualGuide;
    public List<NTrigger> triggers = new List<NTrigger>();

    public NTrigger startTrigger;
    public GameObject startAnnotation;

    float yOffset = -1f;

    Vector3 linePos = Vector3.one;

    int lineIndex = 0;
    #endregion

    #region GUIDE LINE VARIABLES
    public LineRenderer line;
    public Color activeLineColor;
    public Color inactiveLineColor;
    public float lineStartWombroom = 0.65f;
    private float lineUpdateCounter = 0;
    private float lineUpdateFrequency = 1f;
    private bool canUpdateLine = false;
#endregion

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
            }
        }
    }

    private void Start()
    {
        visualGuide.ShowVisual(false);

        //line.material = new Material(Shader.Find("Sprites/Default"));
        //DrawGuideLine(); 

    }

    public void StartNarrative()
    {
        startAnnotation.SetActive(false);
        startTrigger.gameObject.SetActive(true);
    }

#region GUIDE LINE
    private void Update()
    {
        //if (Input.GetKeyUp(KeyCode.O))
        //{
        //    SetLineFromWombToEnd();
        //}
        //if (!canUpdateLine) return;

        //if (lineUpdateCounter >= lineUpdateFrequency)
        //{
        //    DrawGuideLine();
        //    lineUpdateCounter = 0;
        //    //print("updating line");
        //}

        //lineUpdateCounter += Time.deltaTime;
    }

    public void DrawGuideLine()
    {
        canUpdateLine = true;
        line.positionCount = triggers.Count;

        yOffset = -1f;

        linePos = Vector3.one;

        lineIndex = 0;
        foreach (var trigger in triggers)
        {
            linePos = trigger.orbLocation.position;

            linePos.y = yOffset;
            line.SetPosition(lineIndex, linePos);
            lineIndex++;
        }
    }

    public void SetLineFromStartToWomb()
    {
        float alpha = 1.0f;
        var gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(activeLineColor, 0f), new GradientColorKey(activeLineColor, 1f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0f), new GradientAlphaKey(alpha, lineStartWombroom), new GradientAlphaKey(0f, lineStartWombroom + 0.01f), new GradientAlphaKey(0, 1f) }
        );

        line.colorGradient = gradient;
    }

    public void SetLineFromWombToEnd()
    {
        float alpha = 1.0f;
        var gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(activeLineColor, 0f), new GradientColorKey(activeLineColor, 1f) },
            new GradientAlphaKey[] { new GradientAlphaKey(0f, 0f), new GradientAlphaKey(0f, lineStartWombroom), new GradientAlphaKey(1f, lineStartWombroom + 0.01f), new GradientAlphaKey(1, 1f) }
        );

        line.colorGradient = gradient;
    }

    public void ShowVisualGuide()
    {
        visualGuide.ShowVisual(true);
    }
    #endregion
}
