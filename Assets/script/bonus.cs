﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bonus : MonoBehaviour
{
    public score scr;
    public TextMeshPro text;
   
    public int rate;
     private void Start() {
        text.text="X"+rate;
        scr = GameObject.FindGameObjectWithTag("Player").GetComponent<score>();
    }
       void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player"){
            scr.finalPoint=scr.finalPoint<rate*scr.scorePoint?rate*scr.scorePoint:scr.finalPoint;
            Destroy(this);
        }
    }


}
