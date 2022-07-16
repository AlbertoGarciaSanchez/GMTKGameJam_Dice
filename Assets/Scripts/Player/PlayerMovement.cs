using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PauseEntity
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    // Interactable Key
    public KeyCode attackKey = KeyCode.Space;

    Vector2 movement;
    private bool isAttacking = false;

    // Overwrite pauseChanged method to disable animator
    public override void pauseChanged(bool newPause){
        base.pauseChanged(newPause);

        animator.enabled = !pauseStatus;
    }

    void Update()
    {
        // Get movement axis and if the user is attacking.
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        isAttacking = Input.GetKey(attackKey);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetBool("Attacking", isAttacking);
    }

    void FixedUpdate()
    {
        // Check Pause status to avoid movement.
        if(base.CheckPauseStatus()){
            return;
        }

        if(!isAttacking){
            rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime); 
        }
    }
}
