using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] Transform equipmentSlotParent;
    [SerializeField] EquipmentSlot[] equipmentSlots;


    public event Action<ItemSlots> OnPointerEnterEvent;
    public event Action<ItemSlots> OnPointerExitEvent;
    public event Action<ItemSlots> OnRightClickEvent;
    public event Action<ItemSlots> OnBeginDragEvent;
    public event Action<ItemSlots> OnEndDragEvent;
    public event Action<ItemSlots> OnDragEvent;
    public event Action<ItemSlots> OnDropEvent;

    public void Init()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].OnRightClickEvent += OnPointerEnterEvent;
            equipmentSlots[i].OnRightClickEvent += OnPointerExitEvent;
            equipmentSlots[i].OnRightClickEvent += OnRightClickEvent;
            equipmentSlots[i].OnRightClickEvent += OnBeginDragEvent;
            equipmentSlots[i].OnRightClickEvent += OnEndDragEvent;
            equipmentSlots[i].OnRightClickEvent += OnDragEvent;
            equipmentSlots[i].OnRightClickEvent += OnDropEvent;
        }
    }  


    private void OnValidate()
    {
        equipmentSlots = equipmentSlotParent.GetComponentsInChildren<EquipmentSlot>();
    }
    public bool AddItem(EquippableItem item, out EquippableItem previousItem)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].EquipmentType == item.EquipmentType)
            {
                previousItem = (EquippableItem)equipmentSlots[i].Item;
                equipmentSlots[i].Item = item;
                return true;
            }
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(EquippableItem item)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].Item == item)
            {
                equipmentSlots[i].Item = null;
                return true;
            }
        }
        return false;
    }
}
