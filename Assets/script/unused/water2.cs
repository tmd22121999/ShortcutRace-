using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water2 : MonoBehaviour
{
    public player thisp;
    // Start is called before the first frame update
        void Update()
    {
        Vector3 direction = new Vector3(0,-9999,0);
        Debug.DrawLine(transform.position+new Vector3(0,2,0),direction);
        RaycastHit hit;
        if (Physics.Raycast(transform.position+new Vector3(0,6,0),direction, out hit, 10399990)){
            if(hit.transform.gameObject.tag=="water"){
                thisp.onWater=true;
            } else{
                thisp.onWater=false;
            }
        }
    }
}
