using Nova;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nova;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeButtonColor : MonoBehaviour
{
    private UIBlock uiBlock;
    private Color defaultColor;
    public Color hoverColor = new Color32(212, 55, 55, 255);

    private void Awake()
    {
        uiBlock = GetComponent<UIBlock>();

        // Sauvegarde la couleur d'origine du bouton
        if (uiBlock != null)
        {
            defaultColor = uiBlock.Color;
        }
    }

    public void OnHoverEnter()
    {
        if (uiBlock != null)
        {
            uiBlock.Color = hoverColor;
        }
    }

    public void OnHoverExit()
    {
        if (uiBlock != null)
        {
            uiBlock.Color = defaultColor;
        }
    }
}

