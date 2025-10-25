using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour {
    private Vector2 movement;
    private Rigidbody2D rb;
    [SerializeField] private int speed = 5;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMovement(InputValue value) {
        movement = value.Get<Vector2>();
    }

    private void FixedUpdate() {
        // happens once every fixed frame rate
        // if it is physics based (rgidbody) it will go here
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime * speed);

        //rb.AddForce(movement * speed);
    }
}
