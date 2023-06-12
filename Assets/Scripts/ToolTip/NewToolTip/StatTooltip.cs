using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class StatTooltip : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI StatNameTxt; 
    [SerializeField] TextMeshProUGUI StatModifiersLabelTxt; 
    [SerializeField] TextMeshProUGUI StatModifiersTxt;

    private StringBuilder sb = new StringBuilder();


    public void ShowToolTip(CharacterStat stat, string statName) 
    {
        StatNameTxt.text = GetStatTopText(stat, statName);

        StatModifiersTxt.text = GetStatModifiersText(stat);

        gameObject.SetActive(true);
    }
    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }

    string GetStatTopText(CharacterStat stat, string statName)
    {
        sb.Length = 0;
        sb.Append(statName);
        sb.Append(" ");
        sb.Append(stat.Value);

        if(stat.Value != stat.BaseValue)
        {
            sb.Append(" (");
            sb.Append(stat.BaseValue);

            if (stat.Value > stat.BaseValue)
            {
                sb.Append("+");
            }

            sb.Append(System.Math.Round(stat.Value - stat.BaseValue, 4));
            sb.Append(")");
        }    

        return sb.ToString();
    }


    string GetStatModifiersText(CharacterStat stat)
    {
        sb.Length = 0;

        foreach (StatModifier mod in stat.StatModifiers)
        {
            if (sb.Length > 0)
            {
                sb.AppendLine();
            }

            if (mod.Value > 0)
            {
                sb.Append("+");
            }
            if(mod.Type == StatModType.Flat)
            {
                sb.Append(mod.Value);
            }
            else
            {
                sb.Append(mod.Value * 100);
                sb.Append("%");
            }

            Item item = mod.Source as Item;

            if(item != null)
            {
                sb.Append("");
                sb.Append(item.ItemName);
            }
            else
            {
                Debug.LogError(" Modifer is not an Equippable Item!");
            }
        }
        return sb.ToString();
    }
}
