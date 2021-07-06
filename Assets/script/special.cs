using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class special : MonoBehaviour
{
    public int species;
    public Transform dest;
    private void OnTriggerStay(Collider other) {

        if(other.gameObject.CompareTag("other") || other.gameObject.CompareTag("Player")){
            switch (species)
            {
                case 1:
                    spec1(other);
                    break;
                case 2:
                    spec2(other);
                    break;
            }     
        } 
    }
    private void spec1(Collider other){
            //other.transform.position = transform.position+new Vector3(0,2,0);
            other.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
            //other.GetComponent<Rigidbody>().AddForce(jump * jumpForce, ForceMode.Impulse);
            other.GetComponent<Rigidbody>().AddForce(new Vector3(0,4,0), ForceMode.Impulse);
    }
    private void spec2(Collider other){
            other.transform.position = new Vector3(dest.transform.position.x,other.transform.position.y,dest.transform.position.z);
    }
}
