using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayerUI : MonoBehaviour
{
    public AudioSource audioSource;
    public Button playButton;
    public Button pauseButton;
    public Button stopButton;

    void Start()
    {        
        playButton.onClick.AddListener(PlayAudio);
        pauseButton.onClick.AddListener(PauseAudio);
        stopButton.onClick.AddListener(StopAudio);
    }

    public void PlayAudio()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

       public void PauseAudio()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }
    public void StopAudio()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}

