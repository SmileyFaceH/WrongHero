using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item", order = 0)]
public class Items : ScriptableObject
{

    new public string name = "Item";
    public Sprite icon = null;

    public virtual void Use()
    {

    }

}
