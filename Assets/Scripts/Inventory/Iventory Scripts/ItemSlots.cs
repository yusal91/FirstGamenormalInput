using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlots : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Image Image;    


    public event Action<ItemSlots> OnPointerEnterEvent;
    public event Action<ItemSlots> OnPointerExitEvent;
    public event Action<ItemSlots> OnRightClickEvent;
    public event Action<ItemSlots> OnBeginDragEvent;
    public event Action<ItemSlots> OnEndDragEvent;
    public event Action<ItemSlots> OnDragEvent;
    public event Action<ItemSlots> OnDropEvent;

    private Color normalColor = Color.white;
    private Color disabledColor = new Color(1, 1, 1, 0);

    private Item _item;
    public Item Item
    {
        get
        {
            return _item;
        }
        set
        {
            _item = value;
            if(_item == null)
            {
                Image.color = disabledColor;   
            }
            else
            {
                Image.sprite = _item.Icon;
                Image.color = normalColor;
            }
        }
    }    

    protected virtual void OnValidate()             // this funtion works only on Editor, funtion in here needs to move to Start.
    {
        if(Image == null)
        {
            Image.GetComponent<Image>();
        }        
    }

    public virtual bool CanReceiveItem(Item item)
    {
        return true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            if (OnRightClickEvent != null)
            {
                OnRightClickEvent(this);       
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(OnPointerEnterEvent != null)
        {
            OnPointerEnterEvent(this);
        }


        //if(Item is EquippableItem)
        //{
        //    itemTooltip.ShowToolTip((EquippableItem)Item);
        //}

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (OnPointerExitEvent != null)
        {
            OnPointerExitEvent(this);
        }
    }

    Vector2 originalPosition;

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragEvent != null)
        {
            OnDragEvent(this);
        }


        //Image.transform.position = Input.mousePosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnBeginDragEvent != null)
        {
            OnBeginDragEvent(this);
        }

        //originalPosition = Image.transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (OnEndDragEvent != null)
        {
            OnEndDragEvent(this);
        }


        //Image.transform.position = originalPosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (OnDropEvent != null)
        {
            OnDropEvent(this);
        }
    }
}
