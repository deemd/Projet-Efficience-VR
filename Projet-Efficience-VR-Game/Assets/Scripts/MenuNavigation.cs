using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nova;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    //public GameObject[] panels; // Assign panels dans l'Inspector
    [SerializeField] private GameObject[] panels;
    private int currentPanelIndex = 0;

    void Start()
    {
        // Activer le premier panel seulement
        ShowPanel(0);
    }

    public void ShowNextPanel()
    {
        if (currentPanelIndex < panels.Length - 1)
        {
            panels[currentPanelIndex].SetActive(false);
            currentPanelIndex++;
            panels[currentPanelIndex].SetActive(true);
        }
    }

    public void LoadSceneExternView()
    {
        SceneManager.LoadScene("Scenes/VRScene-ExternView");
    }

    public void LoadSceneInternView()
    {
        SceneManager.LoadScene("Scenes/VRScene-InternView");
    }

    private void ShowPanel(int index)
    {
        // Désactive tous les panels
        foreach (GameObject panel in panels)
            panel.SetActive(false);

        // Active le bon panel
        panels[index].SetActive(true);
    }
}

