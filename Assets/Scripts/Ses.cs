using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ses : MonoBehaviour
{
    private AudioClip waterClip;
    private AudioSource audioSource;

   

    private void Start()
    {
        waterClip = Resources.Load<AudioClip>("SuSesi");
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = waterClip;
        audioSource.Stop();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            audioSource.Play();
            Debug.Log("ses");
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            audioSource.Stop();
        }
    } 
}
