using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Potions", fileName = "New Health Potion")]
public class HealthPotion : Items
{
    public int healthHealing;
    PlayerHealth playerHealth; 


    void Start()
    {
        playerHealth = PlayerHealth.instance; 
    }


    public override void Use()
    {
        base.Use();
        ApplyHealing();
    }

    public void ApplyHealing()
    {
        PlayerHealth.instance.ModifyHealth(healthHealing);
    }

}
