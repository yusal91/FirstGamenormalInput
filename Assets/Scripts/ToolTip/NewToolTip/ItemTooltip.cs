using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

public class ItemTooltip : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ItemNameTxt; 
    [SerializeField] TextMeshProUGUI ItemSlotTxt;
    [SerializeField] TextMeshProUGUI ItemStatsTxt;

    private StringBuilder sb = new StringBuilder();


    public void ShowToolTip(EquippableItem item)
    {
        ItemNameTxt.text = item.name;
        ItemSlotTxt.text = item.EquipmentType.ToString();

        sb.Length = 0;
        AddStat(item.StrengthBonus, "Strength");
        AddStat(item.AgilityBonus, "Agility");
        AddStat(item.IntelligenceBonus, "Intelligence");
        AddStat(item.VitalityBonus, "Vitality");

        AddStat(item.StrengthParcentBonus, "Strength", isPercent: true);
        AddStat(item.AgilityParcentBonus, "Agility", isPercent: true);
        AddStat(item.IntelligenceParcentBonus, "Intelligence", isPercent: true);
        AddStat(item.VitalityParcentBonus, "Vitality", isPercent: true);

        ItemStatsTxt.text = sb.ToString();

        gameObject.SetActive(true);
    }
    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }

    void AddStat(float value, string statsName, bool isPercent = false)
    {
        if(value != 0)
        {
            if(sb.Length > 0)
            {
                sb.AppendLine();
            }
            if(value > 0)
            {
                sb.Append("+");
            }
            if(isPercent)
            {
                sb.Append(value * 100);
                sb.Append("% ");
            }
            else
            {
                sb.Append(value);
                sb.Append(" ");

            }

            sb.Append(statsName);
        }
    }
}
