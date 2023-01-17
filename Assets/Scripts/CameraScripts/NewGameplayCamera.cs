using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NewGameplayCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] Vector2 clampAxis = new Vector2(60, 60);

    [SerializeField] float follow_Smoothing = 5;
    [SerializeField] float rotate_Smoothing = 5;
    [SerializeField] float senstivity = 60;

    float rotX, rotY;
    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 target_P = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, target_P, follow_Smoothing * Time.deltaTime);
        

        CameraTargetRotation();
    }


    void CameraTargetRotation()
    {
        transform.LookAt(target);
        Vector2 mouseAxis = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        rotX += (mouseAxis.x * senstivity) * Time.deltaTime; 
        rotY += (mouseAxis.y * senstivity) * Time.deltaTime; 

        rotY = Mathf.Clamp(rotY, clampAxis.x, clampAxis.y); 

        Quaternion localRotation = Quaternion.Euler(rotY, rotX, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, localRotation, Time.deltaTime * rotate_Smoothing);
    }
}
