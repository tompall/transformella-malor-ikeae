using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramItem : MonoBehaviour
{

    public HologramItemData ItemData;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(ItemData.localPosX, ItemData.localPosY, ItemData.localPosZ);
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
        ItemData.localPosX = transform.position.x;
        ItemData.localPosY = transform.position.y;
        ItemData.localPosZ = transform.position.z;
    }
}
