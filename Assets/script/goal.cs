using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    public int rank;
    public GameController gameController;
    GameObject[] another;

    private void Start() {
         another= GameObject.FindGameObjectsWithTag("other");
    }
       void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player"){
            rank++;
            other.gameObject.GetComponent<player>().passGoal=true;
            gameController.activeBonus();
            foreach(var x in another){
                Destroy(x);
            }
        }else if(other.gameObject.tag=="other"){
            other.gameObject.GetComponent<player>().passGoal=true;
            rank++;
            Destroy(other.gameObject);
        }
    }
}
