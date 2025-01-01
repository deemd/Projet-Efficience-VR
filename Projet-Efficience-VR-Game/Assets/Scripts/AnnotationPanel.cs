using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnotationPanel : MonoBehaviour
{
    #region Attributes
    public GameObject panel; // Associez ici l'UI de l'annotation
    #endregion

    #region Methods
    /// <summary>
    /// Assure que le panel est désactivé au début.
    /// </summary>
    void Start()
    {
        if (panel != null)
            panel.SetActive(false);
    }

    /// <summary>
    /// Active ou désactive le panel associé.
    /// </summary>
    public void TogglePanel()
    {
        if (panel != null)
            panel.SetActive(!panel.activeSelf);
    }
    #endregion
}
