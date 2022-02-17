using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{

    public float rayDistance;
    [SerializeField] private float destroyTimer;

    
    [SerializeField] private bool interactable = false;

    public Material[] material;
    Renderer render; 



    void Start()
    {
       render = GetComponent<Renderer>();
        render.enabled = true;
        render.sharedMaterial = material[0]; 
    }

    public virtual void Interact()
    {
        Destroy(gameObject); 
    }


    void Update() 
    {

        if (interactable && Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
            if (interactable)
            {
                render.sharedMaterial = material[1]; 
            }
                else
                {
                    render.sharedMaterial=material[0];
                }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            interactable = false; 
        }

    }

}
