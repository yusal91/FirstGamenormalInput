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

    public float staminaCostOnDash = 5;


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
        onDashing();
    }  

    void UpdatePlayerMovement()
    {
        playerMovementBehaviour.UpdateMovementData(smoothInputMovement);
    }

    void CalculateMovementInputSmoothing()
    {
        smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * movementSmoothingSpeed);
    }

    void OnMovement(Vector3 inputMovement)    
    {
        inputMovement.x = Input.GetAxis("Horizontal");        
        inputMovement.z = Input.GetAxis("Vertical");
        
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.z);
        rawInputMovement = PlayerSlop();      // testing if dash can be used only on ground       
    }

    private Vector3 PlayerSlop()
    {
        RaycastHit groundcheckHit = new RaycastHit();
        Vector3 calculatedPlayermovement = rawInputMovement;
        if(playerMovementBehaviour.onGround())
        {
            Vector3 localGroundeCheckHitNormal = playerMovementBehaviour.playerRigidbody.transform.InverseTransformDirection
                                                  (groundcheckHit.normal);
            float groundSlopeAngel = Vector3.Angle(localGroundeCheckHitNormal, playerMovementBehaviour.playerRigidbody.transform.up);
            if(!(groundSlopeAngel == 0f))
            {
                Quaternion slopeAngleRotation = Quaternion.FromToRotation(playerMovementBehaviour.playerRigidbody.transform.up, 
                                                localGroundeCheckHitNormal);
                calculatedPlayermovement = slopeAngleRotation * calculatedPlayermovement;
            }
#if UNITY_EDITOR
            Debug.DrawRay(playerMovementBehaviour.playerRigidbody.position, 
                          playerMovementBehaviour.playerRigidbody.transform.TransformDirection(calculatedPlayermovement), 
                          Color.red, 0.5f);
#endif
        }

        return calculatedPlayermovement;
    }
 

    void onJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            playerMovementBehaviour.jump();            
        }
    }

    void onDashing()
    {    
        if(Input.GetMouseButton(1) && UiManager.instance.currentStamina >= staminaCostOnDash)
        {
            StartCoroutine(playerMovementBehaviour.ContinuesDash());
            Debug.Log("Dashing");
            UiManager.instance.UseStminaWhenDash(staminaCostOnDash);            
        }
        else 
        {
            StopCoroutine(playerMovementBehaviour.ContinuesDash());            
        }
    }

    public void OnDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(playerMovementBehaviour.Dash());
            Debug.Log("Dashing");
        }
    }
}
