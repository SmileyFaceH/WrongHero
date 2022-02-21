using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSFX : MonoBehaviour
{

    public AudioSource source;
    public AudioClip[] audioClipArray;

    void Start()
    {
        source = GetComponent<AudioSource>();
        OnEnemyDamageEvents.OnEnemyDamage += RandomDamageNoise;
    }


    void RandomDamageNoise()
    {
        source.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
        source.PlayOneShot(source.clip);
    }
}
