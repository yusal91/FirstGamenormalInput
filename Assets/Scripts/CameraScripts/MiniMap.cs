using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;


    private void LateUpdate()
    {
        Vector3 newPostion = player.position;
        newPostion.y = transform.position.y;
        transform.position = newPostion;

        // incase if you i want rotation for mini map
        //transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 90f);
    }

}
