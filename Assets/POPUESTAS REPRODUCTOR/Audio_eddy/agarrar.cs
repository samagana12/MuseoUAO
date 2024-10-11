using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class agarrar : MonoBehaviour
{
    private AudioSource audioSource;
    private XRGrabInteractable grabInteractable;

    public GameObject controlCanvas;

    public Button pauseResumeButton;
    public Button speedUpButton;
    public Button slowDownButton;

    private bool isPaused = false;

    // Referencias a los XR Ray Interactors de las manos
    public XRRayInteractor rightHandRayInteractor;
    public XRRayInteractor leftHandRayInteractor;

    private XRRayInteractor currentRayInteractor;  // Guarda el Ray Interactor de la mano que agarra el objeto

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);

        if (controlCanvas != null)
        {
            controlCanvas.SetActive(false);
        }

        if (pauseResumeButton != null)
            pauseResumeButton.onClick.AddListener(TogglePauseResume);

        if (speedUpButton != null)
            speedUpButton.onClick.AddListener(SpeedUpAudio);

        if (slowDownButton != null)
            slowDownButton.onClick.AddListener(SlowDownAudio);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }

        if (controlCanvas != null)
        {
            controlCanvas.SetActive(true);
        }

        // Identificar cuál mano está agarrando el objeto (derecha o izquierda)
        XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;
        
        if (interactor == rightHandRayInteractor)
        {
            currentRayInteractor = rightHandRayInteractor;
        }
        else if (interactor == leftHandRayInteractor)
        {
            currentRayInteractor = leftHandRayInteractor;
        }

        // Activar el rayo de la mano que está agarrando el objeto
        if (currentRayInteractor != null)
        {
            currentRayInteractor.gameObject.SetActive(true);
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        if (controlCanvas != null)
        {
            controlCanvas.SetActive(false);
        }

        // Desactivar el rayo cuando el objeto es soltado
        if (currentRayInteractor != null)
        {
            currentRayInteractor.gameObject.SetActive(false);
            currentRayInteractor = null;  // Limpiar la referencia
        }
    }

    private void TogglePauseResume()
    {
        if (audioSource != null)
        {
            if (isPaused)
            {
                audioSource.Play();
                isPaused = false;
            }
            else
            {
                audioSource.Pause();
                isPaused = true;
            }
        }
    }

    private void SpeedUpAudio()
    {
        if (audioSource != null)
        {
            audioSource.pitch = Mathf.Clamp(audioSource.pitch + 0.1f, 0.1f, 3f);  // Incrementa el pitch hasta un máximo de 3x
        }
    }

    private void SlowDownAudio()
    {
        if (audioSource != null)
        {
            audioSource.pitch = Mathf.Clamp(audioSource.pitch - 0.1f, 0.1f, 3f);  // Decrementa el pitch hasta un mínimo de 0.1x
        }
    }

    void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }
}