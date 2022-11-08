using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayCamera : MonoBehaviour
{
    public Transform trackerTarget;
    public float sSpeed = 10f;
    public Vector3 dist;
    public Transform lookTarget;
  


    void LateUpdate()
    {
        Vector3 dPos = trackerTarget.position + dist;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);       // lerp makes character have continue rotate. slerp stops that
        transform.position = sPos;
        transform.LookAt(lookTarget.position);
    }
}
