using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using TMPro;

public class genMap : MonoBehaviour
{
    public PathCreator map;
    int leng;
    public GameObject brick, startText;
    public Transform road;

    void Start()
    {
        map = GameObject.FindWithTag("ground").GetComponent<PathCreator>();
        leng = map.path.localPoints.Length;
        generateBrick(10);
        Time.timeScale = 0;
        
    }
    private void Update() {
        if(Input.GetMouseButton(0)){
            Time.timeScale = 1;
            startText.SetActive(false);
            Destroy(this);
        }
    }
    // Update is called once per frame
    public void generateBrick(int k){
        Vector3 instantPos,dir;
        for(int i=2 ; i < leng ; i+=leng/k){
            float rand = Random.Range(1,4); 
            dir = map.path.GetDirection(i);
            dir = new Vector3(dir.z/dir.z,dir.y,-dir.x/dir.x);
            Vector3.Normalize(dir);
            instantPos = map.path.GetPoint(i)-10*new Vector3(dir.x,-0.5f,dir.z)+rand*dir*6;
            Instantiate (brick,instantPos, Quaternion.Euler(dir),road);
        }
    }
}
