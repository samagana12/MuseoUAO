using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerAudio : MonoBehaviour
{
    public List<AudioSource> audios = new List<AudioSource>();
    public bool bienvenida = false;

    private void OnTriggerEnter(Collider other)
    {
        

        switch (other.gameObject.tag)
        {
            case "Bienvenida":
                if (!audios[0].isPlaying)
                {
                    PlayAudio(0);
                }
                break;

            case "Tutorial":
                if (!audios[1].isPlaying)
                {
                    PlayAudio(1);

                }
                break;

            case "Metafora":
                if (!audios[2].isPlaying)
                {
                    PlayAudio(2);
                }
                break;

            case "Entrada":
                if (!audios[3].isPlaying)
                {
                    PlayAudio(3);
                }
                break;

            case "Rojo1":
                if (!audios[4].isPlaying)
                {
                    PlayAudio(4);
                }
                break;

            case "Rojo2":
                if (!audios[5].isPlaying)
                {
                    PlayAudio(5);
                }
                break;

            case "Naranja1":
                if (!audios[6].isPlaying)
                {
                    PlayAudio(6);
                }
                break;

            case "Naranja2":
                if (!audios[7].isPlaying)
                {
                    PlayAudio(7);
                }
                break;

            case "Afro1":
                if (!audios[8].isPlaying)
                {
                    PlayAudio(8);
                }
                break;

            case "Verde1":
                if (!audios[9].isPlaying)
                {
                    PlayAudio(9);
                }
                break;

            case "Verde2":
                if (!audios[10].isPlaying)
                {
                    PlayAudio(10);
                }
                break;

            default:
                break;
        }
    }

    public void PlayAudio(int num)
    {
        for (int i = 0; i < audios.Count; i++)
        {
            if (num != i)
            {
                audios[i].Stop();
            }
        }

        audios[num].Play();
    }
}
