using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<InventoryItemData, IventoryItem> m_itemDictionary;
    public List<IventoryItem> inventory { get; private set; }

    private void Awake()
    {
        inventory = new List<IventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, IventoryItem>();
    }

    public void Add(InventoryItemData referenceDate)
    {
        if(m_itemDictionary.TryGetValue(referenceDate, out IventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            IventoryItem newItem = new IventoryItem(referenceDate);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceDate, newItem);
        }
    }

    public void Remove(InventoryItemData referenceDate)
    {
        if(m_itemDictionary.TryGetValue(referenceDate, out IventoryItem value))
        {
            value.RemoveFromStack();

            if(value.stackSize == 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceDate);
            }
        }
    }
}
