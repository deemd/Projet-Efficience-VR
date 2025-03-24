using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject Target;

    void Update()
    {
        // transform.LookAt(Target.transform.position);
        transform.rotation = Target.transform.rotation;
    }
}
