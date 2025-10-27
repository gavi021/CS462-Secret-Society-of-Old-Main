using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour {
    private Vector2 movement;
    private Rigidbody2D rb;
    [SerializeField] private int speed = 5;
    private Animator animator;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnMovement(InputValue value) {
        movement = value.Get<Vector2>();
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            animator.SetBool("IsWalking", true);
        } else
        {
            animator.SetBool("IsWalking", false);
        }

    }

    private void FixedUpdate() {
        // happens once every fixed frame rate
        // if it is physics based (rgidbody) it will go here
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime * speed);

        //rb.AddForce(movement * speed);
    }
}
