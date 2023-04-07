using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isUnderwater = false;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float underwaterGravity = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        rb.isKinematic = false;
        // Check if the character is underwater
        if (isUnderwater)
        {
            rb.gravityScale = underwaterGravity;

            // Move the character up or down while underwater
            float verticalInput = Input.GetAxisRaw("Vertical");
            float VmoveDirection = verticalInput * moveSpeed;
            rb.velocity = new Vector2(rb.velocity.x, VmoveDirection);

            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float HmoveDirection = horizontalInput * moveSpeed;
            rb.velocity = new Vector2(HmoveDirection, rb.velocity.y);

        }
        else
        {
            rb.gravityScale = 1f;

            // Move the character left or right while on land
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float moveDirection = horizontalInput * moveSpeed;
            rb.velocity = new Vector2(moveDirection, rb.velocity.y);

            // Make the character jump if the space bar is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {

            Invoke("ChangeBool", 0.4f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            
            isUnderwater = false;
        }
    }

    void ChangeBool()
    {
        isUnderwater = true;
    }

}

