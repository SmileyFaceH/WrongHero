using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private Vector3 direction;

    private void Update()
    {
        ShootDirection();
    }

    public void ShootDirection()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
