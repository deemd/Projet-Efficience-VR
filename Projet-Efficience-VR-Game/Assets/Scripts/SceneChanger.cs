using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class SceneChanger : MonoBehaviour
{
    #region Attributes
    public GameObject leftControllerGameObject; // Accepte un GameObject dans l'Inspector
    private XRController leftController; // Composant XR Controller obtenu dynamiquement
    public string targetSceneName; // Nom de la scène cible
    #endregion

    #region Main
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
            // Charge la scène
            SceneManager.LoadScene(targetSceneName);
        }
    }
    #endregion

    #region Methods
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie que le ray interactor vise cette icône
        if (other.CompareTag("Player"))
        {
            // Active l'écoute du bouton "A"
            Update();
        }
    }
    #endregion
}
