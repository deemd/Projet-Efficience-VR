using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelToggle : MonoBehaviour
{
    #region Attributes
    public GameObject annotationPanel; // Le panneau � afficher/masquer
    #endregion

    #region Main
    #endregion

    #region Methods
    public void TogglePanel()
    {
        if (annotationPanel != null)
        {
            // Inverse l'�tat actif du panneau
            annotationPanel.SetActive(!annotationPanel.activeSelf);
        }
    }
    #endregion
}
