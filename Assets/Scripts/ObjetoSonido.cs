using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjetoSonido : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    public GameObject AudioCanvas;
    public AudioSource audioSource;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void Start()
    {
        if (AudioCanvas != null)
        {
            AudioCanvas.SetActive(false);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        
        XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;

        if (interactor != null)
        {
            if (interactor.CompareTag("LeftHand"))
            {
                if (AudioCanvas != null)
                {
                    AudioCanvas.SetActive(true);
                }
            }
            else if (interactor.CompareTag("RightHand"))
            {
                if (AudioCanvas != null)
                {
                    AudioCanvas.SetActive(true);
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

        if (AudioCanvas != null)
        {
            AudioCanvas.SetActive(false);
        }
    }
}
