using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectInteractionAudio : MonoBehaviour
{
    private AudioSource audioSource;
    private XRGrabInteractable grabInteractable;

    bool ActAudio;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            ActAudio=!ActAudio;
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (audioSource != null && ActAudio)
        {
            audioSource.Play();
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (audioSource != null)
        {
            ActAudio= false;
            audioSource.Stop();
        }
    }
}

