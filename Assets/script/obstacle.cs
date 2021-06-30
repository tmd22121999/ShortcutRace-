using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    private float y=0.0f;
    private float rotationSpeed;

    void Start()
    {
        rotationSpeed = 75.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            y += Time.deltaTime * rotationSpeed;
        transform.localRotation = Quaternion.Euler(90, y, 0);
    }
}
