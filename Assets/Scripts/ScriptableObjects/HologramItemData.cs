using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Hologram/Item", order = 100)]
public class HologramItemData : ScriptableObject
{
    public float localPosX;
    public float localPosY;
    public float localPosZ;

    public float localParentRotx;
    public float localParentRoty;
    public float localParentRotz;

    public float localRotx;
    public float localRoty;
    public float localRotz;

    public float localSx;
    public float localSy;
    public float localSz;

}
