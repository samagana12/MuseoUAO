using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlar_Audio : MonoBehaviour
{
    public GameObject canvas;
    public Slider audioSlider;
    public AudioSource audioSource;
    public Collider interactionZone; // Asigna el collider de la zona de interacción
    private bool isInZone = false;

    private void Start()
    {
        // Asegúrate de que el canvas esté desactivado al inicio
        canvas.SetActive(false);
        audioSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void Update()
    {
        if (isInZone)
        {
            // Actualiza el slider con el progreso del audio
            audioSlider.value = audioSource.time / audioSource.clip.length;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == interactionZone)
        {
            isInZone = true;
            canvas.SetActive(true);
            audioSource.Play(); // Reproducir audio al entrar
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == interactionZone)
        {
            isInZone = false;
            canvas.SetActive(false);
            audioSource.Pause(); // Pausar audio al salir
        }
    }

    public void OnSliderValueChanged(float value)
    {
        if (audioSource.clip != null)
        {
            audioSource.time = value * audioSource.clip.length;
        }
    }

    public void ToggleAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }
}
