using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleporting : MonoBehaviour
{
    public Button teleportButton;
    public GameObject destination;
    public Transform player;
    public GameObject loadingDuringTeleporting;


    public void TeleportButtonPressed(GameObject destination)
    {
        player.transform.position = destination.transform.position;
        loadingDuringTeleporting.SetActive(true);

        StartCoroutine(DelayDuringTeleporting(1f));
    }

    IEnumerator DelayDuringTeleporting(float loadingTime)
    {       
        yield return new WaitForSeconds(loadingTime);
        loadingDuringTeleporting.SetActive(false);
    }
}
