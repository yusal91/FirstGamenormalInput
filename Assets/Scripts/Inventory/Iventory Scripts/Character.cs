using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [Header("Character Stats")]
    public CharacterStat Strength;
    public CharacterStat Agility;
    public CharacterStat Intelligence;
    public CharacterStat vitality; 

    [Header("Inventory")]
    [SerializeField] Inventory inventory;

    [Header("Equipmen")]
    [SerializeField] EquipmentPanel equipmentPanel;

    [Header("Stats Panel")]
    [SerializeField] StatsPanel statsPanel;

    [Header("Item Tooltip")]
    [SerializeField] ItemTooltip itemTooltip;

    [Header("Dragable Item Image")]
    [SerializeField] Image dragableItem;

    private ItemSlots draggedSlot;


    private void OnValidate()
    {
        // this funtion needs to change 
        if(itemTooltip == null)
            itemTooltip = FindObjectOfType<ItemTooltip>();
    }


    private void Awake()
    {
        statsPanel.SetStats(Strength, Agility, Intelligence, vitality);
        statsPanel.UpdateStatValues();

        // Set up Event for right clicks
        inventory.OnRightClickEvent += Equip;
        equipmentPanel.OnRightClickEvent += Unequip;
        // pointer Enter
        inventory.OnPointerEnterEvent += ShowtoolTip;
        equipmentPanel.OnPointerEnterEvent += ShowtoolTip;
        // pointer Enter
        inventory.OnPointerExitEvent += HideTooltip;
        equipmentPanel.OnPointerExitEvent += HideTooltip;
        // Begin Drag
        inventory.OnBeginDragEvent += BeginDrag;
        equipmentPanel.OnBeginDragEvent += BeginDrag;
        // End Drag
        inventory.OnEndDragEvent += EndDrag;
        equipmentPanel.OnEndDragEvent += EndDrag;
        // Drag
        inventory.OnDragEvent += Drag;
        equipmentPanel.OnDragEvent += Drag;
        // Drop
        inventory.OnDropEvent += Drop;
        equipmentPanel.OnDropEvent += Drop;



        inventory.Init();                    // this code needs to run after the events above or just change Init funtion back to Start
        equipmentPanel.Init();               // this code needs to run after the events above or just change Init funtion back to Start
    }

    private void Drop(ItemSlots dropItemSlot)
    {
        if(dropItemSlot.CanReceiveItem(draggedSlot.Item) && draggedSlot.CanReceiveItem(dropItemSlot.Item))
        {
            EquippableItem dragItem = draggedSlot.Item as EquippableItem;
            EquippableItem dropItem = dropItemSlot.Item as EquippableItem;

            if(draggedSlot is EquipmentSlot)
            {
                if (dragItem != null)
                {
                    dragItem.Unequip(this);
                }
                if (dragItem != null)
                {
                    dragItem.Equip(this);
                }
            }
            if(dropItemSlot is EquipmentSlot)
            {
                if (dragItem != null)
                {
                    dragItem.Equip(this);
                }
                if (dragItem != null)
                {
                    dragItem.Unequip(this);
                }
            }
            statsPanel.UpdateStatValues();

            Item draggedItem = draggedSlot.Item;
            draggedSlot.Item = dropItemSlot.Item;
            dropItemSlot.Item = draggedItem;
        }
    }

    private void Drag(ItemSlots itemSlot)
    {
        if(dragableItem.enabled)
            dragableItem.transform.position = Input.mousePosition;
    }

    private void EndDrag(ItemSlots itemSlot)
    {
        draggedSlot = null;
        dragableItem.enabled = false;
    }

    private void BeginDrag(ItemSlots itemSlot)
    {
        if(itemSlot.Item != null)
        {
            draggedSlot = itemSlot;
            dragableItem.sprite = itemSlot.Item.Icon;
            dragableItem.transform.position = Input.mousePosition;
            dragableItem.enabled = true;
        }
    }

    private void HideTooltip(ItemSlots itemSlot)
    {
        itemTooltip.HideToolTip();
    }

    private void ShowtoolTip(ItemSlots itemSlot)
    {
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if (equippableItem != null)
        {
            itemTooltip.ShowToolTip(equippableItem);
        }
    }

    public void Equip(ItemSlots itemSlot)
    {
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if (equippableItem != null)
        {
            Equip(equippableItem);
        }
    }

    public void Unequip(ItemSlots itemSlot)
    {
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if (equippableItem != null)
        {
            Unequip(equippableItem);
        }
    }


    public void Equip(EquippableItem item)
    {
        if(inventory.RemoveItem(item))
        {
            EquippableItem previousItem;
            if(equipmentPanel.AddItem(item, out previousItem))
            {
                if(previousItem != null)
                {
                    inventory.AddItem(previousItem);

                    previousItem.Unequip(this);
                    statsPanel.UpdateStatValues();
                }
                item.Equip(this);
                statsPanel.UpdateStatValues();
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }
    public void Unequip(EquippableItem item)
    {
        if(inventory.IsFull()&& equipmentPanel.RemoveItem(item))
        {
            inventory.AddItem(item);

            item.Unequip(this);
            statsPanel.UpdateStatValues();
        }
    }
}
