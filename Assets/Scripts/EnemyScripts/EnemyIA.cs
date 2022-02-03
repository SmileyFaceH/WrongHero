using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float maxSpeed; 
    [SerializeField] private float maxDistance;
    [SerializeField] private float detectionDistance;
    [SerializeField] private float rotationTime;
    [SerializeField] private EnemyType enemyType;
    public BoxCollider enemySwordCollider;


    [SerializeField] private enum EnemyType
    {
        FollowEnemy,
        WatcherEnemy,
        IdleEnemy,
        PatrolEnemy,
    }
    

    private void Start()
    {
        SetEnemyType(enemyType);


    }

    private void SetEnemyType(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.FollowEnemy:
                maxSpeed = 4;
                maxDistance = 1;
                detectionDistance = 4;
                rotationTime = 5; 
                break;
            case EnemyType.WatcherEnemy:
                maxSpeed = 0;
                maxDistance = 0;
                detectionDistance = 10;
                rotationTime = 5;
                break;
            case EnemyType.IdleEnemy:
                maxSpeed = 0;
                maxDistance = 0;
                detectionDistance = 0;
                rotationTime = 0;
                break;
            case EnemyType.PatrolEnemy:
                maxSpeed = 3;
                maxDistance = 1;
                detectionDistance = 4;
                rotationTime = 5;
                break; 

        }
    }


    private void Update()
    {
        Chase(); 
        
    }

   

    public void Chase()
    {
        var distance = Vector3.Distance(transform.position, target.position);

        if (distance > detectionDistance) return;
      
        var direction = (target.position - transform.position).normalized;

        transform.position += maxSpeed * Time.deltaTime * direction;

        if (distance < maxDistance)
        {
            transform.position += maxSpeed * Time.deltaTime * -direction;

            GetComponent<Animator>().SetTrigger("Attack");
        }
       
        Rotation();
    }


    void SwordColliderOn()
    {
        enemySwordCollider.enabled = true;
    }

    void SwordColliderOff()
    {
        enemySwordCollider.enabled = false;
    }

    private void Rotation()
    {
        Quaternion newRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotationTime * Time.deltaTime);

    }

}
