using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadzone : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)      // ha ehhez �r hozz� akkor haljon meg. ez a saj�t colliconje
    {
        if (collision.tag == "Player") 
        {
            Time.timeScale = 0;
            Destroy(collision.gameObject); 
        }
    }
}
