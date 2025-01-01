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
        // Sauvegarder les �tats initiaux
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }
    #endregion

    #region Methods
    public void ResetToInitial()
    {
        // R�initialiser position et rotation
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
    #endregion

}
