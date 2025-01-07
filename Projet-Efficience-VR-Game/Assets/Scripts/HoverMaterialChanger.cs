using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverMaterialChanger : MonoBehaviour
{
    #region Attributes
    [Header("Materials")]
    public Material hoverMaterial; // Mat�riau utilis� pendant le hover

    private List<Renderer> childRenderers; // Liste des renderers des enfants
    private Dictionary<Renderer, Material[]> originalMaterials; // Sauvegarde des mat�riaux d'origine

    private XRGrabInteractable interactable;
    #endregion

    #region Main
    #endregion

    #region Methods
    void Awake()
    {
        // R�cup�re tous les renderers des enfants
        childRenderers = new List<Renderer>(GetComponentsInChildren<Renderer>());

        // Sauvegarde les mat�riaux d'origine de chaque renderer
        originalMaterials = new Dictionary<Renderer, Material[]>();
        foreach (Renderer renderer in childRenderers)
        {
            originalMaterials[renderer] = renderer.materials;
        }

        // R�cup�re le XRGrabInteractable et abonne les �v�nements
        interactable = GetComponent<XRGrabInteractable>();
        if (interactable != null)
        {
            interactable.hoverEntered.AddListener(OnHoverEnter);
            interactable.hoverExited.AddListener(OnHoverExit);
        }
    }

    void OnDestroy()
    {
        // D�sabonne les �v�nements pour �viter des erreurs
        if (interactable != null)
        {
            interactable.hoverEntered.RemoveListener(OnHoverEnter);
            interactable.hoverExited.RemoveListener(OnHoverExit);
        }
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        // Change la couleur en mat�riau de hover
        SetMaterial(hoverMaterial);
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        // Restaure les mat�riaux d'origine
        RestoreOriginalMaterials();
    }

    private void SetMaterial(Material material)
    {
        foreach (Renderer renderer in childRenderers)
        {
            // Applique le mat�riau de hover � tous les enfants
            renderer.material = material;
        }
    }

    private void RestoreOriginalMaterials()
    {
        foreach (Renderer renderer in childRenderers)
        {
            // Restaure les mat�riaux d'origine pour chaque renderer
            if (originalMaterials.ContainsKey(renderer))
            {
                renderer.materials = originalMaterials[renderer];
            }
        }
    }
    #endregion
}
