﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    Animator playerAnimator;
    public bool isUnderwater = false;
    public bool facingRight = true;
    public Transform firepoint;
    public GameObject bullet;

    public int maxBreath = 30;
    public int currentBreath;
    public NefesBar nefesBar;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float underwaterGravity = 0f;
    private float nextFireTime = 0.0f;
    public float fireRate = 0.8f;  //Ateş etme zamanı

    private float timer = 0f;
    private float interval = 5f;


    private void Start()
    {
        currentBreath = maxBreath;
        nefesBar.SetMaxBreath(maxBreath);
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        
    }


    private void Update()
    {
        rb.isKinematic = false;
        // Check if the character is underwater
        if (isUnderwater)
        {

            timer += Time.deltaTime;

            if (timer >= interval)
            {
                
                LoverBreath(15); 
                timer = 0f;
            }
            rb.gravityScale = underwaterGravity;
            playerAnimator.SetBool("isSwimming", true);

            // Move the character up or down while underwater
            float verticalInput = Input.GetAxisRaw("Vertical");
            float VmoveDirection = verticalInput * moveSpeed;
            rb.velocity = new Vector2(rb.velocity.x, VmoveDirection);
            
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float HmoveDirection = horizontalInput * moveSpeed;
            rb.velocity = new Vector2(HmoveDirection, rb.velocity.y);

            

            if (rb.velocity.x < 0 && facingRight)//y�z� sa�a do�ru ba�lang��taki gibi ama ivme negatif ,y�z�n� �evir
            {
                FlipFace();//Yuzunu cevir metodu
                firepoint.transform.rotation = Quaternion.Euler(0, 0, 180);

            }
            else if (rb.velocity.x > 0 && !facingRight)
            {
                FlipFace(); //Yuzunu cevir metodu
                firepoint.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
            
        }
        else
        {
            nefesBar.SetBreath(maxBreath);
            currentBreath= maxBreath;

            playerAnimator.SetBool("isSwimming", false);
            rb.gravityScale = 1f;

            // Move the character left or right while on land
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float moveDirection = horizontalInput * moveSpeed;
            playerAnimator.SetBool("isRunning", Input.GetAxis("Horizontal") != 0);
            rb.velocity = new Vector2(moveDirection, rb.velocity.y);

            if (rb.velocity.x < 0 && facingRight)//y�z� sa�a do�ru ba�lang��taki gibi ama ivme negatif ,y�z�n� �evir
            {
                FlipFace();//Yuzunu cevir metodu
                

            }
            else if (rb.velocity.x > 0 && !facingRight)
            {
                FlipFace(); //Yuzunu cevir metodu
                
            }
            
           
        }

        
    }
    void LoverBreath(int value)
    {
       
        currentBreath -= value;
        nefesBar.SetBreath(currentBreath);
        if(currentBreath == 0)
        {
            ScoreCounter.scoreValue = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            
            Invoke("ChangeBool", 0.4f);
            Debug.Log("Suda");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            
            isUnderwater = false;
            Debug.Log("Suda değil");
        }
    }

    void ChangeBool()
    {
        isUnderwater = true;
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
        

    }

    void Shoot()
    {
        if (Time.time > nextFireTime)
        {
            Instantiate(bullet, firepoint.position, firepoint.rotation);
            nextFireTime = Time.time + fireRate;  // Karakterin tekrar ateş edebileceği zamanı güncelle
        }
    }
    
}

