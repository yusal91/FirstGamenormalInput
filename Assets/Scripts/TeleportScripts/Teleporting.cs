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



    public void TeleportButtonPressed()
    {
        StartCoroutine(DelayDuringTeleporting());
    }

    IEnumerator DelayDuringTeleporting()
    {
        float loadingTime = 1f;
        player.transform.position = destination.transform.position;
        loadingDuringTeleporting.SetActive(true);
        yield return new WaitForSeconds(loadingTime);
        loadingDuringTeleporting.SetActive(false);
    }
}
