using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OnEnemyDamageEvents : MonoBehaviour
{
    public static event Action OnEnemyDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Arma" || other.tag == "BuffedSword")
        {
            OnEnemyDamage?.Invoke();
        }
    }
}
