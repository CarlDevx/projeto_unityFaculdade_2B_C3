using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField]
    private float speed = 15f;
    private float horizontalAxis;
    [SerializeField]
    private bool isOnFloor = false;
    [SerializeField]
    private float jumpForce = 30f;
    void Awake(){
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space) && isOnFloor){
            rb.AddForce(Vector2.up * jumpForce);
        }
        switch (horizontalAxis)
        {
            case < 0:
                spriteRenderer.flipX = true;
                break;
            case > 0:
                spriteRenderer.flipX = false;
                break;
            default:
                spriteRenderer.flipX = spriteRenderer.flipX;
                break;
        }
    }
    void FixedUpdate(){
        rb.velocity = new Vector2(horizontalAxis * speed, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")) {
            isOnFloor = true;
            animator.SetBool("idle",true);
            animator.SetBool("jump", false);
        }
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            animator.SetBool("idle", false);
            animator.SetBool("jump", true);
            isOnFloor = false;
        }
    }
}
