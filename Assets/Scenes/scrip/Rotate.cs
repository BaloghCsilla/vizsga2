using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    Rigidbody2D rb;
    public float angularspeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        rb.angularVelocity = 0;
        transform.Rotate(0, 0, -angularspeed * Time.deltaTime);
    }
}
