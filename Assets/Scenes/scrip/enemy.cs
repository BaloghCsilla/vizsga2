using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy : MonoBehaviour      
{ 
    
    public float PlayerCheckRadius;
    public Transform Playercheck;
    public LayerMask whatIsPlayer;
    public bool playerDetected;

    

    void Update()
    {
        CollisionChecks();
    }

    void CollisionChecks()
    {
        playerDetected = Physics2D.OverlapCircle(Playercheck.position, PlayerCheckRadius, whatIsPlayer);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerDetected)
        {
            Destroy(gameObject);
            Debug.Log("maghalt");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Playercheck.position, PlayerCheckRadius);
    }
}
