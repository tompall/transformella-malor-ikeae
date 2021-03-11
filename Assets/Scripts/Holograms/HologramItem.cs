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
  //  public Transform rotationControls;
   // public Transform controlParent;


    // Start is called before the first frame update
    void Start()
    {
        hologramToSave.transform.localPosition = new Vector3(ItemData.localPosX, ItemData.localPosY, ItemData.localPosZ);


        // Quaternion m_HologramTargetRot *= Quaternion.Euler(ItemData.localRotx, ItemData.localRoty, ItemData.localRotz);
        hologramToSave.transform.localRotation = Quaternion.Euler(ItemData.localRotx, ItemData.localRoty, ItemData.localRotz);
        //   mesh.transform.localScale = new Vector3(pinchSlider.SliderValue, pinchSlider.SliderValue, pinchSlider.SliderValue);
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
        ItemData.localPosX = hologramToSave.transform.position.x;
        ItemData.localPosY = hologramToSave.transform.position.y;
        ItemData.localPosZ = hologramToSave.transform.position.z;
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
