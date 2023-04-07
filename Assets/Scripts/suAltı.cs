using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suAltı : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 2f;
    public float waterDrag = 2f;
    private bool inWater = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (inWater)
        {
            // Disable the Rigidbody2D component
            rb.isKinematic = true;

            // Get the input axis values for horizontal and vertical movement
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            // Calculate the movement vector
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f) * moveSpeed * Time.deltaTime;

            // Move the player character
            transform.position += movement;
        }
        else
        {
            // Re-enable the Rigidbody2D component
            rb.isKinematic = false;
        }

        // Handle jumping
        if (Input.GetKeyDown(KeyCode.Space) && inWater)
        {
            // Apply a jump force
            transform.position += new Vector3(0f, jumpForce, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            inWater = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            inWater = false;
        }
    }

}
