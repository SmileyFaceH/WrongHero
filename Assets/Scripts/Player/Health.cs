using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currentHealth = 100;

    private float amount; 

    public Image healthBar; 

    void Update()
    {

        currentHealth = Mathf.Clamp(currentHealth, 0, 100);

        healthBar.fillAmount = currentHealth / 100;

        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            HealDamage(10);
        }
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount; 
    }

    void HealDamage(int amount)
    {
        currentHealth += amount;
    }
}
