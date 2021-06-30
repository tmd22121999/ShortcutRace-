using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water2 : MonoBehaviour
{
    public player thisp;
    // Start is called before the first frame update
        void Update()
    {
        Vector3 direction = new Vector3(0,-1,0);
        Debug.DrawRay(transform.position,direction);
        RaycastHit hit;
        if (Physics.Raycast(transform.position,direction, out hit, Mathf.Infinity)){
            if(hit.transform.gameObject.tag=="water"){
                thisp.onWater=true;
            } else{
                thisp.onWater=false;
            }
        }
    }
}
