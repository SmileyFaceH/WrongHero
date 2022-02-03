using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class OnDamageEvents : MonoBehaviour
{
    public static event Action OnDamage;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyWeapon")
        {
           OnDamage?.Invoke();
        }
    }
}
