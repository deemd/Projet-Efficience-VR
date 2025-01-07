using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternSceneChangerIcon : MonoBehaviour
{
    #region Attributes
    public float rotationSpeed = 10f; // Rotation speed
    public float translationSpeed = 1f; // Oscillation speed (higher = faster)
    public float minHeight = 0f; // Minimal height
    public float maxHeight = 2f; // Maximal height

    private float originalY; // Initial position on Y axis
    #endregion

    #region Main
    // Start is called before the first frame update
    void Start()
    {
        originalY = transform.position.y; // Save object initial position
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation on Y axis
        transform.Rotate(rotationSpeed, 0, 0);

        // Translation on Y axis
        float oscillation = Mathf.Sin(Time.time * translationSpeed); // Oscillation sinusoïdale
        float newY = Mathf.Lerp(minHeight, maxHeight, (oscillation + 1) / 2f); // Mappe sinusoïde entre minHeight et maxHeight
        transform.position = new Vector3(transform.position.x, originalY + newY, transform.position.z);
    }
    #endregion

    #region Methods
    #endregion
}
