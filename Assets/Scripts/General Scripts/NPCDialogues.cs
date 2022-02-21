using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogues : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject npcCamera;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject dogPosition;
    [SerializeField] private GameObject player;
    public bool isQuestDone; 

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !isQuestDone)
        {
            isQuestDone = true; 
            SetPosition();
            SetGameObjects();
        }
    }
    

    void SetPosition()
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = dogPosition.transform.position;
        player.transform.rotation = dogPosition.transform.rotation;
        
    }

    void SetGameObjects()
    {
        mainCamera.enabled = false;
        npcCamera.SetActive(true);
        canvas.SetActive(true);
    }

    public void SetGameObjectsBack()
    {
        mainCamera.enabled = true; 
        npcCamera.SetActive(false);
        canvas.SetActive(false);
        player.GetComponent<CharacterController>().enabled = true;
    }
}
