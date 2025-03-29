using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioZone : MonoBehaviour
{
    public AudioSource audioSource; // El AudioSource que se controlará

    bool ActAudio;    
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            ActAudio = !ActAudio;
        }
    }
    // Se ejecuta cuando un objeto entra al trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null && !audioSource.isPlaying && ActAudio)
            {
                audioSource.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null && audioSource.isPlaying)
            {
                ActAudio = false;
                audioSource.Stop();
            }
        }
    }
}

