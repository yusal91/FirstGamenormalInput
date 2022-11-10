using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    private int playerID;

    [Header("Sub Behaviours")]
    public PlayerMovementBehaviour playerMovementBehaviour;    
    //public PlayerAnimationBehaviour playerAnimationBehaviour;
    


    [Header("Input Movement Settings")]    
    public float movementSmoothingSpeed = 1f;
    private Vector3 rawInputMovement;
    private Vector3 smoothInputMovement;

    public float fallMultiplier;     // ahmm will ask the teacher
    


    public void SetupPlayer()             //(int newPlayerID)
    {
        playerMovementBehaviour.SetupBehaviour();
    }

    //Update Loop - Used for calculating frame-based data
    void Update()
    {
        OnMovement(smoothInputMovement);
        CalculateMovementInputSmoothing();
        UpdatePlayerMovement();        
        onJump();
        OnDash();
    }  

    void UpdatePlayerMovement()
    {
        playerMovementBehaviour.UpdateMovementData(smoothInputMovement);
    }

    void CalculateMovementInputSmoothing()
    {
        smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * movementSmoothingSpeed);
    }

    public void OnMovement(Vector3 inputMovement)    
    {
        inputMovement.x = Input.GetAxis("Horizontal");        
        inputMovement.z = Input.GetAxis("Vertical");
        
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.z);
    }

    public void onJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            playerMovementBehaviour.jump();            
        }
    }

    public void OnDash()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(playerMovementBehaviour.Dash());
            Debug.Log("Dashing");
        }
    }
}
