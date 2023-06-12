using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EquippableItem : Item
{
    [Header("Main Stats")]
    [Range(1, 999)]
    public int StrengthBonus;
    [Range(1, 999)]
    public int AgilityBonus;
    [Range(1, 999)]
    public int IntelligenceBonus;
    [Range(1, 999)]
    public int VitalityBonus;

    [Header("Parcentage Stats")]
    
    public float StrengthParcentBonus;
    public float AgilityParcentBonus;
    public float IntelligenceParcentBonus;
    public float VitalityParcentBonus;
    [Header("EquipmentType")]
    public EquipmentType EquipmentType;


    public void Equip(Character chr)
    {
        if(StrengthBonus != 0)
        {
            chr.Strength.AddModifier(new StatModifier(StrengthBonus, StatModType.Flat, this));
        }
        if (AgilityBonus != 0)
        {
            chr.Agility.AddModifier(new StatModifier(AgilityBonus, StatModType.Flat, this));
        }
        if (IntelligenceBonus != 0)
        {
            chr.Intelligence.AddModifier(new StatModifier(IntelligenceBonus, StatModType.Flat, this));
        }
        if (VitalityBonus != 0)
        {
            chr.vitality.AddModifier(new StatModifier(VitalityBonus, StatModType.Flat, this));
        }

        //--------------------------------------------------------------------------------------------------//

        if(StrengthParcentBonus != 0)
        {
            chr.Strength.AddModifier(new StatModifier(StrengthParcentBonus, StatModType.PercentMult, this));
        }
        if (AgilityParcentBonus != 0)
        {
            chr.Agility.AddModifier(new StatModifier(AgilityParcentBonus, StatModType.PercentMult, this));
        }
        if (IntelligenceParcentBonus != 0)
        {
            chr.Intelligence.AddModifier(new StatModifier(IntelligenceParcentBonus, StatModType.PercentMult, this));
        }
        if (VitalityParcentBonus != 0)
        {
            chr.vitality.AddModifier(new StatModifier(VitalityParcentBonus, StatModType.PercentMult, this));
        }



    }

    public void Unequip(Character chr)
    {
        chr.Strength.RemoveAllModifiersFromSource(this);
        chr.Agility.RemoveAllModifiersFromSource(this);
        chr.Intelligence.RemoveAllModifiersFromSource(this);
        chr.vitality.RemoveAllModifiersFromSource(this);
    }

}

public enum EquipmentType
{
    None, Weapon, OffHandWeapon, Head, Chest, Hands, Legs, Boots, Neck, Braceltte, Ring 
}
