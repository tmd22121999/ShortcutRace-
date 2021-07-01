using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class special : MonoBehaviour
{
    //public Transform goal;
    void Start()
    {
       // goal=GameObject.FindWithTag("goal").transform;
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag=="other" || other.gameObject.tag=="Player"){
            //other.transform.position = transform.position+new Vector3(0,2,0);
            other.GetComponent<Rigidbody>().AddForce(new Vector3(0,200,0));
            Debug.Log("jump");
        }
    }
}
