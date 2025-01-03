using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class PanelController : MonoBehaviour
{
    // public GameObject panel; // Assigner le panel ici
    // public XRController leftController; // Assigner le contrôleur gauche ici
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject leftControllerGameObject; // Accepte un GameObject dans l'Inspector
    private XRController leftController; // Composant XR Controller obtenu dynamiquement

    private void Start()
    {
        // Récupère le composant XR Controller depuis le GameObject
        leftController = leftControllerGameObject.GetComponent<XRController>();
    }

    private void Update()
    {
        if (leftController != null &&
            leftController.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool isPressed) && isPressed)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }

    /*
    private void Update()
    {
        if (leftController.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool isPressed) && isPressed)
        {
            // Active/désactive le panel
            panel.SetActive(!panel.activeSelf);
        }
    }*/
}

