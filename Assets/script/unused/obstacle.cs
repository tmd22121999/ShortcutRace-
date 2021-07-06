using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public int species;
    public float maxRotation = 20,rotationSpeed;
    private float y=0.0f;

   

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (species)
        {
            case 1:
                y += Time.deltaTime * rotationSpeed;
                transform.localRotation = Quaternion.Euler(90, y, 0);
                break;
            case 2:
                if(y > maxRotation)
                    rotationSpeed=-rotationSpeed;
                if(y < -maxRotation)
                    rotationSpeed=-rotationSpeed;
                y += Time.deltaTime * rotationSpeed;
                
                transform.localRotation = Quaternion.Euler(y, 0, 0);
                break;
        }     
    }
}
