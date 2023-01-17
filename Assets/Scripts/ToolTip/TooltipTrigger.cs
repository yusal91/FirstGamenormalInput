using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerDownHandler
{
    [Header("Name")]
    public string header;
    [TextArea]
    public string content;  


    public void OnPointerEnter(PointerEventData eventData)
    {          
        TooltipSystem.Show(content, header);
        Debug.Log( "mouse over");
    }

    public void OnPointerExit(PointerEventData eventData)
    {        
        TooltipSystem.Hide();       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
               
    }
}
