using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAtDying : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador ha caido, volver al Spawn");
            target.transform.position = spawnPoint.transform.position;
        }
    }
}