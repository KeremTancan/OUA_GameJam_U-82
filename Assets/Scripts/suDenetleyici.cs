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
            GetComponent<suÜstü>().enabled = false;
            GetComponent<suAltý>().enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            inWater = false;
            GetComponent<suÜstü>().enabled = true;
            GetComponent<suAltý>().enabled = false;
        }
    }
}
