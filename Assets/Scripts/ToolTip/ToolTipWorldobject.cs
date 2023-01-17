using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipWorldobject : MonoBehaviour
{
    [Header("Name and Description")]
    public string header;
    [TextArea]
    public string content;
    

    public void OnMouseEnter()
    {
        TooltipSystem.Show(header, content);
    }

    public void OnMouseExit()
    {
        TooltipSystem.Hide();
    }

    public void OnMouseDown()
    {
        WMScript.instance.toolTipCanvas.SetActive(false);
        WMScript.instance.areYouShowObject.SetActive(true);
        Debug.Log("MouseDown");

        //WorldMapScript.instance.areYouShowObject.SetActive(true);
        //TooltipSystem.Hide();

        //TooltipSystem.instance.yesButton.onClick.Invoke();
        //YesButtonToChangeScene();    
    }

}
