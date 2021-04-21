using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool isRunning = animator.GetBool("isRunning");
        bool isWalking = animator.GetBool("isWalking");
        bool isBackwards = animator.GetBool("isBackwards");
        bool forwardPressed = Input.GetKey("w");
        bool walkPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKey("space");
        bool inAir = animator.GetBool("inAir");
        bool backwardsPressed = Input.GetKey("s");

        if(!isRunning && forwardPressed) // run state on w key
        {
            animator.SetBool("isRunning", true);
        }
        if(isRunning && !forwardPressed) // return to idle if no w key from run state
        {
            animator.SetBool("isRunning", false);
        }
        if(!isWalking && (forwardPressed && walkPressed)) // walk state when running on w + left shift
        {
            animator.SetBool("isWalking", true);
        }
        if(isWalking && (!forwardPressed || !walkPressed)) // return to idle if no w key from walk state
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
