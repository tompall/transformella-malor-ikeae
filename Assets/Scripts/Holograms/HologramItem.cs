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

    [SerializeField]
    private bool isEditorResettable = false;
    public bool saveScale;

    private Vector3 editorPosition;
    private Quaternion editorRotation;
    private Vector3 editorScale;

    //  public Transform rotationControls;
    // public Transform controlParent;

    private void Awake()
    {
        editorPosition = transform.localPosition;
        editorRotation = transform.localRotation;
        editorScale = transform.localScale;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        this.transform.localPosition = new Vector3(ItemData.localPosX, ItemData.localPosY, ItemData.localPosZ);
        this.transform.localRotation = Quaternion.Euler(ItemData.localParentRotx, ItemData.localParentRoty, ItemData.localParentRotz);

        // Quaternion m_HologramTargetRot *= Quaternion.Euler(ItemData.localRotx, ItemData.localRoty, ItemData.localRotz);
        hologramToSave.transform.localRotation = Quaternion.Euler(ItemData.localRotx, ItemData.localRoty, ItemData.localRotz);
        //   mesh.transform.localScale = new Vector3(pinchSlider.SliderValue, pinchSlider.SliderValue, pinchSlider.SliderValue);
        if (saveScale)
        {
            this.transform.localScale = new Vector3(ItemData.localSx, ItemData.localSy, ItemData.localSz);
        }
    }

    void Start()
    {
        this.transform.localPosition = new Vector3(ItemData.localPosX, ItemData.localPosY, ItemData.localPosZ);
        this.transform.localRotation = Quaternion.Euler(ItemData.localParentRotx, ItemData.localParentRoty, ItemData.localParentRotz);

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
        if (!isEditorResettable) return;

        if (Input.GetKeyUp(KeyCode.Alpha0)){
            Debug.Log("Reset position attempt");
            transform.localPosition = editorPosition;
            transform.localRotation = editorRotation;
            if (saveScale) transform.localScale = editorScale;
            SaveLocalPos();
            SaveLocalRot();
        }
    }

    public void ResetDataToEditor()
    {
        transform.localPosition = editorPosition;
        transform.localRotation = editorRotation;
        if (saveScale) transform.localScale = editorScale;
        SaveLocalPos();
        SaveLocalRot();
    }

    public void SaveHologramData()
    {

    }

    public void SaveLocalPos()
    {
        SaveLocalRot();

        ItemData.localPosX = this.transform.localPosition.x;
        ItemData.localPosY = this.transform.localPosition.y;
        ItemData.localPosZ = this.transform.localPosition.z;

        ItemData.localParentRotx = this.transform.localEulerAngles.x;
        ItemData.localParentRoty = this.transform.localEulerAngles.y;
        ItemData.localParentRotz = this.transform.localEulerAngles.z;

        if (saveScale)
        {
            ItemData.localSx = this.transform.localScale.x;
            ItemData.localSy = this.transform.localScale.y;
            ItemData.localSz = this.transform.localScale.z;
        }
    }

    public void SaveLocalRot()
    {
        ItemData.localRotx = hologramToSave.transform.localEulerAngles.x;
        ItemData.localRoty = hologramToSave.transform.localEulerAngles.y;
        ItemData.localRotz = hologramToSave.transform.localEulerAngles.z;
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
