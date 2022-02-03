using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [CreateAssetMenu(menuName = "ScriptableObjects/Enemy", fileName = "NewEnemeyData", order = 0)] 
public class EnemiesData : ScriptableObject
{
    public float enemyHp;
    public float swordDamage;
    public float buffedDamage; 

}
