using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData refrenceItem;

    public void OnHandlePickupItem()
    {
        //InventorySystem.current.Add(refrenceItem);
        Destroy(gameObject);
    }
}
