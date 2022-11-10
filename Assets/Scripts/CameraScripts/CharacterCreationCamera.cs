using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreationCamera : MonoBehaviour
{
    public Transform player;
    public float _mouseSensitivity = 10f;
   
    private Vector3 _currentRotation;

    private float _rotationY;
    private float _rotationX;

    public float _distanceFromTarget = 3f;
    public Vector3 smothVelocity = Vector3.zero;    
    public float _smothTime = 3f;
    void LateUpdate()
    {    
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        _rotationY += mouseX;
        _rotationX += mouseY;

        Debug.Log(mouseX);
        Debug.Log(mouseY);

        _rotationX = Mathf.Clamp(_rotationX, -40, 40);

        Vector3 nextRotation = new Vector3(_rotationX, _rotationY);
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref smothVelocity, _smothTime);
        transform.localEulerAngles = _currentRotation;

        transform.position = player.position - transform.forward * _distanceFromTarget;
    }
}
