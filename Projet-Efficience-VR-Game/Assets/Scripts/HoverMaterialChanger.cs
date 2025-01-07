using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverMaterialChanger : MonoBehaviour
{
    #region Attributes
    [Header("Materials")]
    public Material hoverMaterial; // Matériau utilisé pendant le hover

    private List<Renderer> childRenderers; // Liste des renderers des enfants
    private Dictionary<Renderer, Material[]> originalMaterials; // Sauvegarde des matériaux d'origine

    private XRGrabInteractable interactable;
    #endregion

    #region Main
    #endregion

    #region Methods
    void Awake()
    {
        // Récupère tous les renderers des enfants
        childRenderers = new List<Renderer>(GetComponentsInChildren<Renderer>());

        // Sauvegarde les matériaux d'origine de chaque renderer
        originalMaterials = new Dictionary<Renderer, Material[]>();
        foreach (Renderer renderer in childRenderers)
        {
            originalMaterials[renderer] = renderer.materials;
        }

        // Récupère le XRGrabInteractable et abonne les événements
        interactable = GetComponent<XRGrabInteractable>();
        if (interactable != null)
        {
            interactable.hoverEntered.AddListener(OnHoverEnter);
            interactable.hoverExited.AddListener(OnHoverExit);
        }
    }

    void OnDestroy()
    {
        // Désabonne les événements pour éviter des erreurs
        if (interactable != null)
        {
            interactable.hoverEntered.RemoveListener(OnHoverEnter);
            interactable.hoverExited.RemoveListener(OnHoverExit);
        }
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        // Change la couleur en matériau de hover
        SetMaterial(hoverMaterial);
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        // Restaure les matériaux d'origine
        RestoreOriginalMaterials();
    }

    private void SetMaterial(Material material)
    {
        foreach (Renderer renderer in childRenderers)
        {
            // Applique le matériau de hover à tous les enfants
            renderer.material = material;
        }
    }

    private void RestoreOriginalMaterials()
    {
        foreach (Renderer renderer in childRenderers)
        {
            // Restaure les matériaux d'origine pour chaque renderer
            if (originalMaterials.ContainsKey(renderer))
            {
                renderer.materials = originalMaterials[renderer];
            }
        }
    }
    #endregion
}
