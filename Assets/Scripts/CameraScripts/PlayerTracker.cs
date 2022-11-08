using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;


public class PlayerTracker : MonoBehaviour
{
    public Transform trackerTarget;
    public float maxDistance = 10;
    public float moveSpeed = 20;
    public float updateSpeed = 10;
    [Range(0, 100)]
    public float currentDistance = 5;
    private string moveAxis = "CameraZoom";
    private GameObject ahead;
    private MeshRenderer _renderer;
    public float hideDistance = 1.5f;

    

    
    void Start()
    {
        ahead = new GameObject("ahead");
        //_renderer = trackerTarget.gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ahead.transform.position = trackerTarget.position + trackerTarget.forward * (maxDistance * 0.25f);

        currentDistance += Input.GetAxisRaw(moveAxis) * moveSpeed * Time.deltaTime;
        currentDistance = Mathf.Clamp(currentDistance, 0, maxDistance);
        transform.position = Vector3.MoveTowards(transform.position, trackerTarget.position + Vector3.up * currentDistance - trackerTarget.forward *
                                                (currentDistance + maxDistance * 0.5f), updateSpeed * Time.deltaTime);
        transform.LookAt(ahead.transform);
        //_renderer.enabled = (currentDistance > hideDistance);
    }    
}
