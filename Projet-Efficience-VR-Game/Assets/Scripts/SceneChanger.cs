using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    #region Attributes
    // public string targetSceneName; // Nom de la scène cible
    #endregion

    #region Main
    #endregion

    #region Methods
    // Méthode publique pour charger une scène par son nom
    public void LoadSceneByName(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName)) // Vérifie que le nom n'est pas vide
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Le nom de la scène est vide ou invalide.");
        }
    }
    #endregion
}
