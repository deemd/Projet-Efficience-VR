using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractionManager : MonoBehaviour
{
    #region Attributes
    public XRRayInteractor rayInteractor; // Le ray interactor utilis�
    public InputHelpers.Button interactionButton = InputHelpers.Button.Trigger; // Bouton principal d'interaction
    public float activationThreshold = 0.1f; // Seuil d'activation du bouton

    public float longPressThreshold = 0.5f; // Temps pour d�tecter un clic long
    public float doubleClickThreshold = 0.3f; // Temps maximum entre deux clics pour d�tecter un double clic

    private float buttonPressTime; // Moment o� le bouton est press�
    private float lastClickTime; // Moment du dernier clic
    private bool isLongPressTriggered; // D�tecte si un clic long a d�j� �t� d�clench�
    #endregion

    #region Main
    void Update()
    {
        // V�rifie si le bouton est enfonc�
        XRController xrController = rayInteractor.GetComponent<XRController>();
        if (xrController != null && xrController.inputDevice.IsPressed(interactionButton, out bool isPressed, activationThreshold))
        {
            if (isPressed)
                HandleButtonPress();
            else
                HandleButtonRelease();
        }
    }
    #endregion

    #region Methods
    private void HandleButtonPress()
    {
        if (buttonPressTime == 0f) // Premier moment d'appui
        {
            buttonPressTime = Time.time;
            isLongPressTriggered = false; // R�initialise le statut du clic long
        }

        // V�rifie si c'est un clic long
        if (!isLongPressTriggered && Time.time - buttonPressTime >= longPressThreshold)
        {
            isLongPressTriggered = true;
            PerformLongPressAction();
        }
    }

    private void HandleButtonRelease()
    {
        if (buttonPressTime > 0f)
        {
            float pressDuration = Time.time - buttonPressTime;

            if (pressDuration < longPressThreshold)
            {
                // D�termine s'il s'agit d'un double clic ou d'un simple clic
                if (Time.time - lastClickTime <= doubleClickThreshold)
                    PerformDoubleClickAction();
                else
                    PerformSingleClickAction();

                lastClickTime = Time.time; // Enregistre le moment du clic
            }

            // R�initialise le statut
            buttonPressTime = 0f;
        }
    }

    /// <summary>
    /// Action effectu�e lors d'un clic bref.
    /// </summary>
    private void PerformSingleClickAction()
    {
        // Affiche le panneau d'annotation de l'objet cibl�
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            // R�cup�re l'objet touch�
            GameObject hitObject = hit.collider.gameObject;

            // Cherche le script AnnotationPanel sur l'objet touch�
            AnnotationPanel annotation = hitObject.GetComponent<AnnotationPanel>();

            if (annotation != null)
                annotation.TogglePanel(); // Appelle une m�thode pour afficher ou cacher le panneau
        }
    }

    private void PerformDoubleClickAction()
    {
        // S�lectionne (grab) l'objet cibl�
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            XRGrabInteractable grabInteractable = hit.collider.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
                rayInteractor.interactionManager.SelectEnter(rayInteractor, grabInteractable);
        }
    }

    private void PerformLongPressAction()
    {
        // R�initialise l'objet cibl� et d�clenche une vibration haptique
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            ResettableObject resettable = hit.collider.GetComponent<ResettableObject>();
            if (resettable != null)
            {
                // Vibration haptique
                HapticFeedback(rayInteractor.GetComponent<XRController>().inputDevice, 0.5f, 0.2f);
                resettable.ResetToInitial();
            }
        }
    }

    private void HapticFeedback(InputDevice device, float amplitude, float duration)
    {
        if (device.TryGetHapticCapabilities(out HapticCapabilities capabilities) && capabilities.supportsImpulse)
            device.SendHapticImpulse(0, amplitude, duration);
    }
    #endregion

}
