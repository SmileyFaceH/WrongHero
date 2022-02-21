using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private EnemiesData enemyData; 
    [SerializeField] private float maxDistance;
    [SerializeField] private Animator anim;
    public EnemyIA enemyIa;
    private bool _enemyBoolValue;
    




    private void Awake()
    {
        enemyIa = GetComponent<EnemyIA>();
    }

    private void Start()
    {
        enemyData.enemyHp = 100; 
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arma")
        {
            if (anim != null)
            {
                anim.Play("GetHit");
            }
            enemyData.enemyHp -= enemyData.swordDamage;
 
        }

        if (other.gameObject.tag == "BuffedSword")
        {
            if (anim != null)
            {
                anim.Play("GetHit");
            }

            enemyData.enemyHp -= enemyData.buffedDamage;
        }

        if (enemyData.enemyHp <= 0)
        {
            Destroy(this);
            enemyIa.enabled = false;
            anim.Play("Die");
            var delay = 5;
            Destroy(gameObject, delay); 
        }
        
        if (other.gameObject.tag == "Shield")
        {
            SetEnemyBool();
        }
    }

    private void SetEnemyBool()
    {
        _enemyBoolValue = !_enemyBoolValue;

        anim.SetBool("blocked", _enemyBoolValue); 
    }
}
