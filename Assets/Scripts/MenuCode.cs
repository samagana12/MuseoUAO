using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuCode : MonoBehaviour
{
    public GameObject Menu;
    public XRRayInteractor rayo;

    public void Restart()
    {
        Menu.SetActive(true);
        SceneManager.LoadScene("Museo", LoadSceneMode.Single);
    }

    public void CloseMenu()
    {
        Menu.SetActive(false);
        rayo.enabled = false;
    }
}
