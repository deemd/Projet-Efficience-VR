using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    #region Attributes
    // public string targetSceneName; // Nom de la sc�ne cible
    #endregion

    #region Main
    #endregion

    #region Methods
    // M�thode publique pour charger une sc�ne par son nom
    public void LoadSceneByName(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName)) // V�rifie que le nom n'est pas vide
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Le nom de la sc�ne est vide ou invalide.");
        }
    }
    #endregion
}
