using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPanel : MonoBehaviour
{
    [SerializeField] StatsDisplay[] statsDisplay;

    [SerializeField] string[] statName; 
    [SerializeField] CharacterStat[] stats;

    private void OnValidate()              // this called in editor  might need to swap it for stats or awake
    {
        statsDisplay = GetComponentsInChildren<StatsDisplay>();

        UpdateStatNames();
    }

    public void SetStats(params CharacterStat[] charStats)
    {
        stats = charStats;

        if(stats.Length > statsDisplay.Length)
        {
            Debug.LogError("Not Enough STats Displays");
        }

        for (int i = 0; i < statsDisplay.Length; i++)
        {
            statsDisplay[i].gameObject.SetActive(i < stats.Length);

            if(i < statsDisplay.Length)
            {
                statsDisplay[i].Stat = stats[i];
            }
        }
    }

    public void UpdateStatValues()
    {
        for (int i = 0; i < stats.Length; i++)
        {
            statsDisplay[i].UpdateStatValue();
        }
    }

    public void UpdateStatNames()
    {
        for (int i = 0; i < statName.Length; i++)
        {
            statsDisplay[i].Name = statName[i];
        }
    }
}
