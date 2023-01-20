using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class IventoryItem 
{
    public InventoryItemData data { get; private set; } 
    public int stackSize { get; private set; }

    public IventoryItem(InventoryItemData source)
    {
        data = source;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }
    public void RemoveFromStack()
    {
        stackSize--;
    }
}
