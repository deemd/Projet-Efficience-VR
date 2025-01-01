using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Message"); // pas Console.Write car console Unity
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, 0, z);
        // Debug.Log(movement);
        // Debug.Log(x);
        // Debug. Log(z);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
