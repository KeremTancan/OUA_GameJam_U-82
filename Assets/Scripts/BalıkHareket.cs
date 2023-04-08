using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BalıkHareket : MonoBehaviour
{
    public float speed = 5f;
    public float changeDirectionTime = 3f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private float timer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = changeDirectionTime;
        ChangeDirection();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            ChangeDirection();
            timer = changeDirectionTime;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
        float newPosY = Mathf.Clamp(rb.position.y, -Mathf.Abs(rb.position.x), 0f); // Y = 0 ı balıkların geçememesini sağlıyor.
        rb.MovePosition(new Vector2(rb.position.x, newPosY) + moveDirection * speed * Time.fixedDeltaTime);
    }

    

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
