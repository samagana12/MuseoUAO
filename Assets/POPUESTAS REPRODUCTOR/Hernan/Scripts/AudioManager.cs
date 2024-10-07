using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource objectAudioSource;
    public AudioSource zoneAudioSource;
    public float reducedVolume = 0.2f;
    private float originalZoneVolume;
    public float fadeSpeed = 2f; // Velocidad de fade
    void Start()
    {
        if (zoneAudioSource != null)
        {
            originalZoneVolume = zoneAudioSource.volume;
        }
    }
    void Update()
    {
        if (objectAudioSource != null && zoneAudioSource != null)
        {
            if (objectAudioSource.isPlaying)
            {
                // Hacer fade-out al volumen de la zona
                zoneAudioSource.volume = Mathf.Lerp(zoneAudioSource.volume, reducedVolume, Time.deltaTime * fadeSpeed);
            }
            else
            {
                // Hacer fade-in al volumen original de la zona
                zoneAudioSource.volume = Mathf.Lerp(zoneAudioSource.volume, originalZoneVolume, Time.deltaTime * fadeSpeed);
            }
        }
    }

}

