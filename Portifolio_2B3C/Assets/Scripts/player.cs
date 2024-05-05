using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private float speed = 15f;
    private float horizontalAxis;
    private bool isOnFloor = false;
    [SerializeField]
    private float jumpForce = 30f;
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space) && isOnFloor){
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
    void FixedUpdate(){
        rb.velocity = new Vector2(horizontalAxis * speed, rb.velocity.y);
    }
}
