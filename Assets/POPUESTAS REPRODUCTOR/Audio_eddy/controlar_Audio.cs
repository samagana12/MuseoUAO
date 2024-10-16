using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlar_Audio : MonoBehaviour
{
    public GameObject canvas;
    public Slider audioSlider;
    public AudioSource audioSource;
    public Collider interactionZone; // Asigna el collider de la zona de interacci�n
    public GameObject rayoDerecho;
    public GameObject rayoIzquierdo;
    public Button pauseResumeButton; // Bot�n para pausar/reanudar el audio

    private bool isInZone = false;
    private bool isPaused = false; // Estado del audio

    private void Start()
    {
        // Aseg�rate de que el canvas est� desactivado al inicio
        canvas.SetActive(false);
        audioSlider.onValueChanged.AddListener(OnSliderValueChanged);

        // Configura el bot�n para que llame a ToggleAudio
        if (pauseResumeButton != null)
        {
            pauseResumeButton.onClick.AddListener(ToggleAudio);
        }
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
        Debug.Log("Entr� en la zona de interacci�n: " + other.name);

        if (other.CompareTag("Player"))
        {
            isInZone = true;
            canvas.SetActive(true);
            audioSource.Play(); // Reproducir audio al entrar
            rayoDerecho.SetActive(true);
            rayoIzquierdo.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = false;
            canvas.SetActive(false);
            audioSource.Pause(); // Pausar audio al salir
            rayoDerecho.SetActive(false);
            rayoIzquierdo.SetActive(false);
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
            isPaused = true; // Cambia el estado a pausado
        }
        else
        {
            audioSource.Play();
            isPaused = false; // Cambia el estado a reproduciendo
        }
    }
}