using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notas : MonoBehaviour
{
    private AudioSource As;
    public string ObjetoGolpeador;
    void Awake()
    {
        As = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(ObjetoGolpeador))
        {
                As.Play();
        }
    }
}

