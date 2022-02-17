using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactions
{
    public Items items;
    PlayerHealth playerHealth;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        items.Use();
    }
}
