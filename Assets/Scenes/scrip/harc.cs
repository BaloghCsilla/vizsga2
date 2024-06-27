using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harc : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")         
        {            
            Destroy(collision.gameObject);
            Debug.Log("halott vagy");
        }
    }
}
