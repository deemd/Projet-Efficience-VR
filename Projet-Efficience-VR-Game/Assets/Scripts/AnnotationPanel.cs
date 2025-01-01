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
    /// Assure que le panel est d�sactiv� au d�but.
    /// </summary>
    void Start()
    {
        if (panel != null)
            panel.SetActive(false);
    }

    /// <summary>
    /// Active ou d�sactive le panel associ�.
    /// </summary>
    public void TogglePanel()
    {
        if (panel != null)
            panel.SetActive(!panel.activeSelf);
    }
    #endregion
}
