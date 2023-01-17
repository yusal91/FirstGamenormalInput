using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.Examples.CameraController;

public class GamePlayCamera : MonoBehaviour
{
    public Transform lookTarget;
    public float sSpeed = 10f;
    public Vector3 dist;   

    public float FollowDistance = 30.0f;
    public float MaxFollowDistance = 100.0f;
    public float MinFollowDistance = 2.0f;
    public float mouseWheel;




    void FixedUpdate()                 // fixed update makes camera less flickery, 
    {
        GetInput();

        Vector3 dPos = lookTarget.position + dist;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);       // lerp makes character have continue rotate. slerp stops that
        transform.position = sPos;       
    }

    void GetInput()
    {
        transform.LookAt(lookTarget.position);
        mouseWheel = Input.GetAxis("Mouse ScrollWheel");

        mouseWheel *= 10;    

        // Check MouseWheel to Zoom in-out
        if (mouseWheel < -0.01f || mouseWheel > 0.01f)
        {

            FollowDistance -= mouseWheel * 5.0f;
            // Limit FollowDistance between min & max values.
            FollowDistance = Mathf.Clamp(FollowDistance, MinFollowDistance, MaxFollowDistance);
        }
    }

}
