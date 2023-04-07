using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isUnderwater = false;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float waterLevel = 0f;
    public float underwaterGravity = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the character is underwater
        if (transform.position.y < waterLevel)
        {
            isUnderwater = true;
        }
        else
        {
            isUnderwater = false;
        }

        // Set the gravity scale according to whether the character is underwater or not
        if (isUnderwater)
        {
            rb.gravityScale = underwaterGravity;
        }
        else
        {
            rb.gravityScale = 1f;
        }

        // Move the character left or right
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float moveDirection = horizontalInput * moveSpeed;
        rb.velocity = new Vector2(moveDirection, rb.velocity.y);

        // Make the character jump if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isUnderwater)
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(new Vector2(0f, jumpForce / 2f), ForceMode2D.Impulse);
            }
        }
    }
}

