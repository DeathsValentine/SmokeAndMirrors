using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CharacterController controller;
    Animator animator;
    public float moveSpeed = 6f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    public float rotationSpeed = 100f;
    private Vector3 moveDirection = Vector3.zero;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;
            if (Input.GetKey("space"))
            {
                
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime); 
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        Animation(); 
    }

    void Animation()
    {
        bool isRunning = animator.GetBool("isRunning");
        bool isWalking = animator.GetBool("isWalking");
        bool isBackwards = animator.GetBool("isBackwards");
        bool movePressed = Input.GetKey("w") || Input.GetKey("a") ||  Input.GetKey("d");
        bool walkPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKey("space");
        bool inAir = animator.GetBool("inAir");
        bool backwardsPressed = Input.GetKey("s");

        if(!isRunning && movePressed) // run state on w key
        {
            animator.SetBool("isRunning", true);
        }
        if(isRunning && !movePressed) // return to idle if no w key from run state
        {
            animator.SetBool("isRunning", false);
        }
        if(!isWalking && (movePressed && walkPressed)) // walk state when running on w + left shift
        {
            animator.SetBool("isWalking", true);
        }
        if(isWalking && (!movePressed || !walkPressed)) // return to idle if no w key from walk state
        {
            animator.SetBool("isWalking", false);
        }
        if(jumpPressed && !inAir) // jump if inAir is false
        {
            animator.SetBool("inAir", true);
        }
        if(!jumpPressed && inAir) // jump if inAir is true
        {
            animator.SetBool("inAir", false);
        }
        if(!isBackwards && backwardsPressed) // run state on s key
        {
            animator.SetBool("isBackwards", true);
        }
        if(isBackwards && !backwardsPressed) // 
        {
            animator.SetBool("isBackwards", false);
        }
    }
    
}
