using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LowGraphics : MonoBehaviour
{
    public PostProcessVolume volume;

    public PostProcessProfile Profile1;
    public PostProcessProfile Profile2;

    private void Start()
    {
        volume = GetComponent<PostProcessVolume>();

        volume.profile = Profile1;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeProfiles();
        }
    }

    void ChangeProfiles() 
    {
        if (volume.profile == Profile1)
            volume.profile = Profile2;
        else
            volume.profile = Profile1;
    }
}
