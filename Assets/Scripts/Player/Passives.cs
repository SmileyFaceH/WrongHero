using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passives : MonoBehaviour
{
    [SerializeField] private bool isBuffedSword;
    [SerializeField] private KeyCode keyCode;
    [SerializeField] private GameObject sword; 
    [SerializeField] private GameObject buffedSword;


    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BuffedSword")
        {
            Debug.Log("El Arma esta buff");
            isBuffedSword = true;
        }
    }


    private void Update()
    {
        if (isBuffedSword & Input.GetKey(keyCode))
        {
            sword.SetActive(false);
            buffedSword.SetActive(true);
        }
    }

}
