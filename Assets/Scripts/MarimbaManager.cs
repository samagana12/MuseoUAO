using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarimbaManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Marimba"))
        {
            other.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
