using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.OpenVR;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class OculusButtons : MonoBehaviour
{
    private ButtonInputs inputs;

    public GameObject Menu;
    public XRRayInteractor rayo;

    private void Awake()
    {
        inputs = new ButtonInputs();        
        Menu.SetActive(false);

        rayo.enabled = false;
    }

    private void OnEnable()
    {
        inputs.Enable();

        inputs.OculusButton.Menu.performed += MenuPressed;
    }

    private void OnDisable()
    {
        inputs.OculusButton.Menu.performed -= MenuPressed;
    }

    private void MenuPressed(InputAction.CallbackContext context)
    {
        rayo.enabled = true;
        Menu.SetActive(true);
    }
}
