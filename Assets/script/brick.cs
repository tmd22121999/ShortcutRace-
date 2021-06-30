using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{
    // Start is called before the first frame update

    public player thisbody;

    void OnTriggerEnter(Collider other)
    {
        if((!thisbody.isKilling) && (!thisbody.isHit))
            if(other.tag=="brick"){
                //player player=this.GetComponent<player>();
                thisbody.changeBrick(1);
                Destroy(other.gameObject);
                //other.gameObject.SetActive(false);
            }
    }
}
