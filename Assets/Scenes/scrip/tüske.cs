using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tüske : MonoBehaviour
{
    Rigidbody2D rb => GetComponent<Rigidbody2D>();



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);            
        }
    }
}

