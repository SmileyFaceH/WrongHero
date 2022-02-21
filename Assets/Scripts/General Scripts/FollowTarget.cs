using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private NPCDialogues npcDialogues;
    [SerializeField]private GameObject questSymbol; 
    void Update()
    {
        
        transform.LookAt(target.transform);

        if (npcDialogues.isQuestDone)
        {
            Destroy(questSymbol);
        }

    }
}
