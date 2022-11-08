using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerDownHandler
{
    private float onPointerDelayEnter = 1f;
    public string header;
    public string content;  


    public void OnPointerEnter(PointerEventData eventData)
    {          
        TooltipSystem.Show(content, header);
        Debug.Log( "mouse over");
        //StartCoroutine(DelayWhenHover());
    }

    public void OnPointerExit(PointerEventData eventData)
    {        
        TooltipSystem.Hide();
        //StartCoroutine(DelayWhenExitHover());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //if(eventData.button == PointerEventData.InputButton.Left)
        //{
        //    Debug.Log("leftMousebuttonPressed");
        //}        
    }

    //IEnumerator DelayWhenHover()
    //{
    //    yield return new WaitForSeconds(onPointerDelayEnter);
    //    TooltipSystem.Show(content, header);
    //}

    //IEnumerator DelayWhenExitHover()
    //{
    //    yield return new WaitForSeconds(onPointerDelayEnter);
    //    TooltipSystem.Hide();
    //}


}
