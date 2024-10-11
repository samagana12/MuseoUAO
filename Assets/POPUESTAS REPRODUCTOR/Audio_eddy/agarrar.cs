using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class agarrar : MonoBehaviour
{
    private AudioSource audioSource;
    private XRGrabInteractable grabInteractable;

    public GameObject leftControlCanvas;  // Canvas para el antebrazo izquierdo
    public GameObject rightControlCanvas; // Canvas para el antebrazo derecho

    public GameObject rayoDerecho;
    public GameObject rayoIzquierdo;

    // Botones para el canvas izquierdo
    public Button leftPauseResumeButton;
    public Button leftSpeedUpButton;
    public Button leftSlowDownButton;

    // Botones para el canvas derecho
    public Button rightPauseResumeButton;
    public Button rightSpeedUpButton;
    public Button rightSlowDownButton;

    private bool isPaused = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);

        // Desactivar ambos canvases al inicio
        if (leftControlCanvas != null)
        {
            leftControlCanvas.SetActive(false);
        }

        if (rightControlCanvas != null)
        {
            rightControlCanvas.SetActive(false);
        }

        // Configurar botones para el canvas izquierdo
        if (leftPauseResumeButton != null)
            leftPauseResumeButton.onClick.AddListener(TogglePauseResume);

        if (leftSpeedUpButton != null)
            leftSpeedUpButton.onClick.AddListener(SpeedUpAudio);

        if (leftSlowDownButton != null)
            leftSlowDownButton.onClick.AddListener(SlowDownAudio);

        // Configurar botones para el canvas derecho
        if (rightPauseResumeButton != null)
            rightPauseResumeButton.onClick.AddListener(TogglePauseResume);

        if (rightSpeedUpButton != null)
            rightSpeedUpButton.onClick.AddListener(SpeedUpAudio);

        if (rightSlowDownButton != null)
            rightSlowDownButton.onClick.AddListener(SlowDownAudio);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // Activar el canvas correspondiente según la mano que agarra el objeto
        XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;

        if (interactor != null)
        {
            if (interactor.CompareTag("LeftHand"))
            {
                if (leftControlCanvas != null)
                {
                    leftControlCanvas.SetActive(true);
                    rayoDerecho.SetActive(true);
                }
            }
            else if (interactor.CompareTag("RightHand"))
            {
                if (rightControlCanvas != null)
                {
                    rightControlCanvas.SetActive(true);
                    rayoIzquierdo.SetActive(true);
                }
            }
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // Desactivar ambos canvases al soltar
        if (leftControlCanvas != null)
        {
            leftControlCanvas.SetActive(false);
            rayoDerecho.SetActive(false);
        }

        if (rightControlCanvas != null)
        {
            rightControlCanvas.SetActive(false);
            rayoIzquierdo.SetActive(false);
        }
    }

    private void TogglePauseResume()
    {
        if (audioSource != null)
        {
            if (isPaused)
            {
                audioSource.UnPause();
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
            audioSource.pitch = Mathf.Clamp(audioSource.pitch + 0.1f, 0.1f, 3f);
        }
    }

    private void SlowDownAudio()
    {
        if (audioSource != null)
        {
            audioSource.pitch = Mathf.Clamp(audioSource.pitch - 0.1f, 0.1f, 3f);
        }
    }

    void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }
}