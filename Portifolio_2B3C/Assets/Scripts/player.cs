using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private RigidBody2D rb;
    [SerializeField]
    private float speed = 15f;
    private float horizontalAxis;
    isOnFloor = false;
    [SerializeField]
    private float jumpForce = 30f;
    void Awake(){
        rb = GetComponent<RigidBody2D>();
    }
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space) && isOnFloor){
            rb.addForce(Vector2.up * jumpForce);
        }
    }
    void FixedUpdate(){
        rb.velocity = new Vector2(horizontalAxis * speed, rb.velocity.y);
    }
}
