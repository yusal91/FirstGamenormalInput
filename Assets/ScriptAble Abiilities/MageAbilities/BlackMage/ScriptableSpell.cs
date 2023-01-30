using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Spell", menuName ="Spell")]
public class ScriptableSpell : ScriptableObject
{
    [Header("About This Spell")]
    public string spellName = "New Spell";
    [TextArea(10, 0)]
    public string spellDescription = "New Description";
    public Texture2D spellSprite;
    [Header("Spell Prefab")]
    public GameObject spellPrefab;

    [Header("Spell Stats")]
    public float mannaCost = 5f;   
    public int damageAmount;
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

