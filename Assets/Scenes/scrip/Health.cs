using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Health : MonoBehaviour
{
    public int startHp = 3;
    int currentHp;

    [SerializeField] TMP_Text healthtext;

    
     void Start()
    {
        currentHp = startHp;
        HealthText();
    }

    void HealthText()
    {
        if (healthtext != null)
            healthtext.text = "Health: " + currentHp;
    }

    void OnTriggerEnter2D(Collider2D other)      // ha akalaphoz ér akkor veszítsen 1 életet. más collisonje
    {

        if (other.gameObject.CompareTag("kalap"))
        {

            currentHp -= 1;

            if (currentHp <= 0 )
                
                Destroy(gameObject);

            HealthText();
            Debug.Log("Current Health: " + currentHp);
        }
    }


}
