using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Spell", menuName ="Spell")]
public class ScriptableSpell : ScriptableObject
{
    public float mannaCost = 5f;
    public float lifeTime = 2f;
    public float speed = 15f;
    public float damageAmount = 10f;

    public float spellRadius { get; internal set; }

    //status effect
    //Thumbnail
    // cooldown
    // magic element

}
