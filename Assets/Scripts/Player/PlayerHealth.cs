using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    #region Singleton
    public static PlayerHealth instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public float currentHealth;
    [SerializeField] private float enemySwordDamage;
    [SerializeField] private Image healthBar;
    [SerializeField] private float skeletonEnemyDamage;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyWeapon")
        {
            currentHealth -= skeletonEnemyDamage;
        }

        if (other.tag == "Ground")
        {
            currentHealth = 0;
        }
    }

    void Update()
    {

        if (currentHealth <= 0)
        {
            GameManager.instance.player.GetComponent<CharacterController>().enabled = false;
            GameManager.instance.player.transform.position = GameManager.instance.spawnPoint.transform.position;
            GameManager.instance.player.GetComponent<CharacterController>().enabled = true;
            currentHealth = 100;
        }


        currentHealth = Mathf.Clamp(currentHealth, 0, 100);

        healthBar.fillAmount = currentHealth / 100;

    }
    
    public void ModifyHealth(int healthModifier)
    {
        currentHealth += healthModifier;
        print(currentHealth);
    }

    
    
    
}
