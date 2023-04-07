using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suÜstü : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float waterDrag = 2f;
    private bool inWater = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        float moveVertical = Input.GetAxis("Vertical");
        _ = new Vector2(moveVertical, 0);
        rb.AddForce(movement * moveSpeed);

        if (inWater)
        {

            
            rb.gravityScale= 0f;
            moveSpeed -= 5;
            rb.AddForce(movement * moveSpeed);

        }
        else
        {
            
            rb.gravityScale= 1;
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
