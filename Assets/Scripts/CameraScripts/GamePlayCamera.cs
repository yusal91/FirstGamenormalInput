using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.Examples.CameraController;
using static UnityEngine.GraphicsBuffer;

public class GamePlayCamera : MonoBehaviour
{
    //public Transform lookTarget;
    //public float sSpeed = 10f;
    //public Vector3 dist;   
    //public float mouseWheel;

    public Transform character;
    public GameObject cameraCenter;  // maincamera
    public float yOffset = 1f;
    public float sensitivity = 3f;
    public Camera cam;

    public float scrollSensitivity = 5f;
    public float scrollDampening = 6f;

    public float zoomMin = 3.5f;
    public float zoomMax = 15f;
    public float zoomDefault = 10f;
    public float zoomDistance;

    public float collisionSensitivity = 4.5f;

    private RaycastHit _camHit;
    private Vector3 camDist;

    private void Start()
    {
        camDist = cam.transform.localScale;
        zoomDistance = zoomDefault;
        camDist.z = zoomDistance;
    }


    void FixedUpdate()                 
    {
        GameCamera();


        //MoveCamera(Input.GetAxis("Mouse ScrollWheel"));

        //Vector3 dPos = lookTarget.position + dist;
        //Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);       // lerp makes character have continue rotate. slerp stops that
        //transform.position = sPos;       
    }

    void GameCamera()
    {
        // The CameraCenter (empty gameobject) follows always the character's position:
        var position1 = character.position;
        cameraCenter.transform.position = new Vector3(position1.x, position1.y + yOffset, position1.z);

        // Rotation of CameraCenter, and thus the camera, depending on Mouse Input:
        var rotation = cameraCenter.transform.rotation;
        rotation = Quaternion.Euler(rotation.eulerAngles.x - Input.GetAxis("Mouse Y") * sensitivity / 2,
                                    rotation.eulerAngles.y + Input.GetAxis("Mouse X") * sensitivity, 
                                    rotation.eulerAngles.z);
        cameraCenter.transform.rotation = rotation;


        // Zooming Input from our Mouse Scroll Wheel
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            var scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;
            scrollAmount *= (zoomDistance * 0.3f);
            zoomDistance += scrollAmount * -1f;
            zoomDistance = Mathf.Clamp(zoomDistance, zoomMin, zoomMax);
        }

        // ReSharper disable once CompareOfFloatsByEqualityOperator
        if (camDist.z != zoomDistance * -1f)
        {
            camDist.z = Mathf.Lerp(camDist.z, -zoomDistance, Time.deltaTime * scrollDampening);
        }


        // Apply calculated camera position
        var transform2 = cam.transform;
        transform2.localPosition = camDist;

        // Check and handle Collision
        GameObject obj = new GameObject();
        obj.transform.SetParent(transform2.parent);
        var position = cam.transform.localPosition;
        obj.transform.localPosition = new Vector3(position.x, position.y, position.z - collisionSensitivity);
        /*
		Linecast is an alternative to Raycast, using it to cast a ray between the CameraCenter 
		and a point directly behind the camera (to smooth things, that's why there's an "obj"
		GameObject, that is directly behind cam)
		*/
        if (Physics.Linecast(cameraCenter.transform.position, obj.transform.position, out _camHit))
        {
            //This gets executed if there's any collider in the way
            var transform1 = cam.transform;
            transform1.position = _camHit.point;
            var localPosition = transform1.localPosition;
            localPosition = new Vector3(localPosition.x, localPosition.y, localPosition.z + collisionSensitivity);
            transform1.localPosition = localPosition;
        }
        // Clean up
        Destroy(obj);

        // Make sure camera can't clip into player because of collision
        if (cam.transform.localPosition.z > -1f)
        {
            cam.transform.localPosition =
                new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, -1f);
        }
    }

    //void MoveCamera(float x)
    //{
    //    transform.LookAt(lookTarget);        

    //    Vector3 scrollAmount = new Vector3(0, 0, x) * mouseWheel * Time.deltaTime;
    //    transform.Translate(scrollAmount);
    //}   
}
