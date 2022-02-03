using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeathEvents : MonoBehaviour
{
    public static event Action OnDeath;
    public PlayerHealth playerHealth; 

    private void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {

            OnDeath?.Invoke();
            
        }
    }

}
