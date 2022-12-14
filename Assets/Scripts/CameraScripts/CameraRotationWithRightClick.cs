using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationWithRightClick : MonoBehaviour
{
    public Transform target;
    public int degrees = 10;
    public int dragSpeed = 10;

    public float speed = 25;
    public float disToTarget = 1f;

    // Update is called once per frame
    void Update()
    {
        MoveCamera(Input.GetAxis("Mouse ScrollWheel"));

        if (Input.GetMouseButton(0))
        {
            degrees = 10;
            transform.LookAt(target);
            transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * degrees);            
            transform.RotateAround(target.position, Vector3.left, Input.GetAxis("Mouse Y") * dragSpeed);
        }       
    }
    void MoveCamera(float x)
    {
        Vector3 movementAmount = new Vector3(0, 0, x) * speed * Time.deltaTime;
        transform.Translate(movementAmount);
    }
}
