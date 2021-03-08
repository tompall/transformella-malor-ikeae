using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextButtonFunctions : MonoBehaviour
{

    private TextMeshPro textButton;

    public Color colourBase;
    public Color colourHover;


    public void Start()
    {
        if (gameObject.GetComponent<TextMeshPro>() != null) { 
        textButton = gameObject.GetComponent<TextMeshPro>();
        }
        Transform child = transform.GetChild(0);
        child.gameObject.SetActive(false);
    }
    public void ClickEnableChild()
    {
        Transform child = transform.GetChild(0);
        child.gameObject.SetActive(true);
    }

    public void DisableTMPro()
    {
        textButton.enabled = false;
    }

    public void ChangeColour()
    {
        textButton.color = colourHover;
    }
    public void ChangeColourBack()
    {
        textButton.color = colourBase;
    }

    //public void ScaleUp()
   // {
   //     StartCoroutine(ScaleUpAndDown(textButton.rectTransform,
   //         textButton.transform.localScale*0.1f,
   //         1f)) ;
   // }

   // public void ScaleDown()
   // {

   // }

   //public  IEnumerator ScaleUpAndDown(RectTransform recttransform, Vector3 upScale, float duration)
  
   // {
        
   //     float elapsedTime = 0;
        
   //     Vector3 currentPos = recttransform.position;

   //     while (elapsedTime < duration)
   //     {
   //         transform.position = Vector3.Lerp(currentPos, upScale, (elapsedTime / duration));
   //         elapsedTime += Time.deltaTime;
   //         yield return null;
   //     }
 
      
   // }
}
