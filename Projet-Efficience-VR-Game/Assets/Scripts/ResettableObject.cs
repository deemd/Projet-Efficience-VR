using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResettableObject : MonoBehaviour
{
    #region Attributes
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    #endregion

    #region Main
    void Start()
    {
        // Sauvegarder les états initiaux
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }
    #endregion

    #region Methods
    public void ResetToInitial()
    {
        // Réinitialiser position et rotation
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
    #endregion

}
