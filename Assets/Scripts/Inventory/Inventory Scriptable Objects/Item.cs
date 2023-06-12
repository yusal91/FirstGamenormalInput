using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [Header("Item Name")]
    public string ItemName;

    [Header("Item description")]
    public string ItemDescription;

    [Header("Item Icon")]
    public Sprite Icon;
}
