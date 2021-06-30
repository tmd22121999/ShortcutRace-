using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    public int rank;
    public GameController gameController;
    GameObject[] another;
    [Header ("Bonus")]
    public GameObject bonusObj;
    public Transform bonusTransform;
    private Vector3 lastPos;
     [TextArea]
    [Tooltip("a và b là max khoảng cách giữa 2 bonus")]
     public string Notes = "a và b là max khoảng cách giữa 2 bonus";
    public float a;
    public float b;

    private void awake() {
         
    }
    private void Start() {
         another = GameObject.FindGameObjectsWithTag("other");
        lastPos = bonusTransform.position;
         genmap(a,b);
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
        public void genmap(float a,float b){
            float x,z;
            GameObject bnOjTmp;
        for(int i=2;i<11;i++){
            float rand = Random.Range(-a, a);
            x = transform.position.x -a/2+ rand;
            rand = Random.Range(lastPos.z+7, lastPos.z+b);
            z = rand;
            lastPos = new Vector3(x,bonusTransform.position.y,z);
            bnOjTmp = Instantiate (bonusObj , lastPos , Quaternion.Euler(new Vector3(0, 0, 0)) , bonusTransform);
            bnOjTmp.GetComponent<bonus>().rate=i;
        }
    }
}
