using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatArcher : MonoBehaviour
{
    [SerializeField] private int enemyHp;
    [SerializeField] private int swordDamage;
    [SerializeField] private int buffedDamage;
    [SerializeField] private float maxDistance;
    [SerializeField] private float destroyTime;
    [SerializeField] private float timeToShoot;
    [SerializeField] private float timeToShootLeft;
    [SerializeField] private Animator anim;
    [SerializeField] private EnemyIA enemyIa;
    [SerializeField] private Transform eyesTransform;
    [SerializeField] private GameObject Arrow;
    [SerializeField] private Vector3 arrowRotation;



    private void Awake()
    {
        enemyIa = GetComponent<EnemyIA>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arma")
        {
            if (anim != null)
            {
                anim.Play("GetHit");
            }
            enemyHp -= swordDamage;

        }

        if (other.gameObject.tag == "BuffedWeapon")
        {
            if (anim != null)
            {
                anim.Play("GetHit");
            }

            enemyHp -= buffedDamage;
        }

        if (enemyHp == 0)
        {
            Destroy(this);
            enemyIa.enabled = false;
            anim.Play("Die");
            var delay = 5;
            Destroy(gameObject, delay);
        }
    }


    private void Update()
    {
        Timer();
    }

    private void Shoot()
    {
        GameObject newArrow;

        newArrow = Instantiate(Arrow, eyesTransform.position, Quaternion.Euler(arrowRotation), transform);

        Destroy(newArrow, destroyTime);
    }

    private void ResetTimer()
    {
        timeToShootLeft = timeToShoot;
    }
    private void Timer()
    {
        timeToShootLeft -= Time.deltaTime;

        if (timeToShootLeft <= 0)
        {
            Shoot();
            ResetTimer();
        }
    }

}
