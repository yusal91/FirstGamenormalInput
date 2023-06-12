using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    [FormerlySerializedAs("items")]
    [SerializeField] List<Item> startingItems = new List<Item>();
    [SerializeField] Transform ItemsParent;
    [SerializeField] ItemSlots[] itemSlots;


    public event Action<ItemSlots> OnPointerEnterEvent;
    public event Action<ItemSlots> OnPointerExitEvent;
    public event Action<ItemSlots> OnRightClickEvent;
    public event Action<ItemSlots> OnBeginDragEvent;
    public event Action<ItemSlots> OnEndDragEvent;
    public event Action<ItemSlots> OnDragEvent;
    public event Action<ItemSlots> OnDropEvent;

    public void Init() 
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnRightClickEvent += OnPointerEnterEvent;
            itemSlots[i].OnRightClickEvent += OnPointerExitEvent;
            itemSlots[i].OnRightClickEvent += OnRightClickEvent;
            itemSlots[i].OnRightClickEvent += OnBeginDragEvent;
            itemSlots[i].OnRightClickEvent += OnEndDragEvent;
            itemSlots[i].OnRightClickEvent += OnDragEvent;
            itemSlots[i].OnRightClickEvent += OnDropEvent;
        }

        SetStartingItems();      // this needs to run in this funtion
    }

    private void OnValidate()     // this funtion runs only on Editor, wont run if you build your game
    {
        if(ItemsParent != null)
        {
            itemSlots = ItemsParent.GetComponentsInChildren<ItemSlots>();
        }
        SetStartingItems();
    }

    void SetStartingItems()
    {
        int i = 0;
       
        for (; i < startingItems.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = startingItems[i];
        }
        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
        }
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {
                itemSlots[i].Item = item;
                return true;
            }
        }
        return false;
    }

    public bool RemoveItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                itemSlots[i].Item = null;
                return true;
            }
        }
        return false;
    }

    public bool IsFull()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {                
                return false;
            }
        }
        return true;
    }
}
