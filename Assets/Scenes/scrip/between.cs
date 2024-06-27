using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class between : MonoBehaviour
{
    [SerializeField] Transform a, b;
    [SerializeField, Range(0, 1)] float rate;
    [SerializeField] float speed = 10;
        bool toA = true;

    
    void Start()

    {
        SetupPosition();
       
    }

    void Update()
    {
        
        if (!Application.isPlaying)
        {
            SetupPosition();
            return;
        }


        if (toA)
        {
            transform.position = Vector3.MoveTowards(transform.position, a.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, a.position) < 0.1f)
                toA = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, b.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, b.position) < 0.1f)
                toA = true;
        }

        
    }
    void SetupPosition() 
    {
        Vector3 center = (a.position + b.position) / 2f;
        // Kisz�m�tjuk az a �s b pontok k�z�tti t�vols�got
        float distance = Vector3.Distance(a.position, b.position);
        // Kisz�m�tjuk az a �s b pontok k�z�tti t�vols�got az adott ar�ny alapj�n
        float currentDistance = distance * rate;
        // Kisz�m�tjuk az a �s b pontok k�z�tti ir�nyt
        Vector3 direction = (b.position - a.position).normalized;
        // Kisz�m�tjuk az a �s b pontok k�z�tti t�vols�got az adott ar�ny alapj�n a k�z�ppontt�l
        Vector3 pointBetweenAB = center - direction * (currentDistance / 2f);

        transform.position = pointBetweenAB;
    }

    
}
