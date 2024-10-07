using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioPlayerController : MonoBehaviour
{
    public GameObject audioPlayerUI; // El UI del reproductor de audio
    public AudioSource audioSource;  // El AudioSource del objeto

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Registrar los eventos de interacción
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);

        // Asegurarse de que el UI del reproductor esté desactivado al inicio
        if (audioPlayerUI != null)
        {
            audioPlayerUI.SetActive(false);
        }
    }

    // Se activa al agarrar el objeto
    private void OnGrab(SelectEnterEventArgs args)
    {
        // Mostrar el UI del reproductor si el objeto tiene audio
        if (audioPlayerUI != null && audioSource != null)
        {
            audioPlayerUI.SetActive(true);
        }
    }

    // Se activa al soltar el objeto
    private void OnRelease(SelectExitEventArgs args)
    {
        // Ocultar el UI del reproductor
        if (audioPlayerUI != null)
        {
            audioPlayerUI.SetActive(false);
        }

        // Detener el audio cuando el objeto se suelte
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}

