using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suDenetleyici : MonoBehaviour
{
    private bool inWater;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            inWater = true;
            GetComponent<su�st�>().enabled = false;
            GetComponent<suAlt�>().enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            inWater = false;
            GetComponent<su�st�>().enabled = true;
            GetComponent<suAlt�>().enabled = false;
        }
    }
}
