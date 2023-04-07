using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float bulletSpeed;
    public float endTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
        Destroy(gameObject, endTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
