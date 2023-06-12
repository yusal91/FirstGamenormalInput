using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class StatsDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private CharacterStat _stat;
    public CharacterStat Stat 
    {
        get
        {
            return _stat;
        }
        set
        {
            _stat = value;
            UpdateStatValue();
        }
    }
   

    private string _name;
    public string Name 
    {
        get { return _name; }
        set
        {
            _name = value;
            nameText.text = _name;
            //nameText.text = _name.ToLower();     // optional if you dont like Strength start with capital S,
        }       
    }

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI valueText;

    [SerializeField] StatTooltip tooltip;

 
    private void OnValidate()
    {
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
        nameText = texts[0];
        valueText = texts[1];

        if(tooltip == null)
        {
            tooltip = FindObjectOfType<StatTooltip>();
        }
    }

    public void UpdateStatValue()
    {
        valueText.text = _stat.Value.ToString();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.ShowToolTip(Stat, Name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideToolTip();
    }
}
