using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReset : MonoBehaviour
{
    [SerializeField] private GameObject SkeletonWatcher;
    [SerializeField] private GameObject SkeletonWatcherSpawn;
    [SerializeField] private GameObject SkeletonPatrol;
    [SerializeField] private GameObject SkeletonPatrolSpawn;
    void Start()
    {
        OnDeathEvents.OnDeath += EnemySpawnReset; 
    }

    void EnemySpawnReset()
    {
        print("Enemies position has been reseted");
        SkeletonWatcher.transform.position = SkeletonWatcherSpawn.transform.position;
        SkeletonPatrol.transform.position = SkeletonPatrolSpawn.transform.position;
    }

    private void OnDisable()
    {
        OnDeathEvents.OnDeath -= EnemySpawnReset;
    }
}
