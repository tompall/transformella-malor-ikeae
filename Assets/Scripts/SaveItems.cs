using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveItems
{
    public List<HologramItemData> hologramItems;

    public void SetHologramitems(List<HologramItemData> _hologramItems)
    {
        hologramItems = _hologramItems;
    }
    
    public List<HologramItemData> GetHologramitems()
    {
        return hologramItems;
    }
}
