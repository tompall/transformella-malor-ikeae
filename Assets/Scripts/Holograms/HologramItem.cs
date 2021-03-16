using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramItem : MonoBehaviour
{

  //  public PinchSlider pinchSlider;

  //  public GameObject mesh;

    public HologramItemData ItemData;
    public Transform hologramToSave;

    public bool saveScale;
  //  public Transform rotationControls;
   // public Transform controlParent;


    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = new Vector3(ItemData.localPosX, ItemData.localPosY, ItemData.localPosZ);


        // Quaternion m_HologramTargetRot *= Quaternion.Euler(ItemData.localRotx, ItemData.localRoty, ItemData.localRotz);
        hologramToSave.transform.localRotation = Quaternion.Euler(ItemData.localRotx, ItemData.localRoty, ItemData.localRotz);
        //   mesh.transform.localScale = new Vector3(pinchSlider.SliderValue, pinchSlider.SliderValue, pinchSlider.SliderValue);
        if (saveScale)
        {
            this.transform.localScale = new Vector3(ItemData.localSx, ItemData.localSy, ItemData.localSz);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveHologramData()
    {

    }

    public void SaveLocalPos()
    {
        ItemData.localPosX = this.transform.localPosition.x;
        ItemData.localPosY = this.transform.localPosition.y;
        ItemData.localPosZ = this.transform.localPosition.z;

        if (saveScale)
        {
            ItemData.localSx = this.transform.localScale.x;
            ItemData.localSy = this.transform.localScale.y;
            ItemData.localSz = this.transform.localScale.z;
        }
    }

    public void SaveLocalRot()
    {
        ItemData.localRotx = hologramToSave.transform.eulerAngles.x;
        ItemData.localRoty = hologramToSave.transform.eulerAngles.y;
        ItemData.localRotz = hologramToSave.transform.eulerAngles.z;
    }

   /* public void ParentRotationControls()
    {
        rotationControls.parent = this.transform;
    }

    public void UnparentRotationControls()
    {
        rotationControls.parent = controlParent;
    }*/

    public void SliderValueChange()
    {
      //  mesh.transform.localScale = new Vector3(pinchSlider.SliderValue, pinchSlider.SliderValue, pinchSlider.SliderValue);
    }
}
