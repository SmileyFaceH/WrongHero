using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageSFX : MonoBehaviour
{

    public AudioSource source;
    public AudioClip[] audioClipArray;

    void Start()
    {
        source = GetComponent<AudioSource>();
        OnDamageEvents.OnDamage += RandomDamageNoise;
    }

    void RandomDamageNoise()
    {
        source.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
        source.PlayOneShot(source.clip);
    }
}
