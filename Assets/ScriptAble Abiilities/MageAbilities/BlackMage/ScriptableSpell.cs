using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Spell", menuName ="Spell")]
public class ScriptableSpell : ScriptableObject
{
    [Header("About This Spell")]
    public string spellName = "New Spell";
    [TextArea]
    public string spellDescription = "New Description";
    public Texture2D spellSprite;
   
    [Header("Spell Stats")]
    public float mannaCost = 5f;   
    public float damageAmount = 10f;
    public float currentCooldown = 0;
    public float maxCooldown;
    public int damageOverTime = 15;
    

    public void PutOnCooldown()
    {
        CooldownManager.instance.StartCooldown(this);
    }

    public bool IsSpellReady()
    {
        if (currentCooldown <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }  
}

