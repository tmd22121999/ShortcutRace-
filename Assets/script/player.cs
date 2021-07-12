﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class player : MonoBehaviour
{
    public int brickCount,brickDefault;
    [Header ("State")]
    public bool onWater=false;
    public bool isHit=false,canKill=true, isKilling=false, passGoal=false;
    
    
    [Header ("Reference")]
    public fov2 fov;
    public GameObject brick,dat,gach;
    [Header ("Other")]
    public float timeGetHit;
    public float cooldown;
    public Vector3 lastBridgePos,stickPos;
    public GameController gameController;
    public JoystickPlayerExample pmove; 
    int layerMask = 1 << 9;
     [HideInInspector]
     public float oldspeed2,RemainTime,mapYPos;
    void Start()
    {
        oldspeed2=pmove.speed;
        brickCount=brickDefault; // số gạch mặc định
        mapYPos=this.transform.position.y - 0.055f;
        brick.transform.localScale += new Vector3(0f, .023f*brickCount*0.71f, 0f);
        brick.transform.localPosition  = new Vector3(stickPos.x-0.023f*brickCount*0.355f, stickPos.y, stickPos.z);
        fov.viewRadius=brickCount * 0.71f + 5; 
        this.GetComponent<Rigidbody>().sleepThreshold = 0.0f;//rigidbody hoạt động khi ko sử dụng
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if(isHit){
            StartCoroutine("ishit");
        }else{
            
            if(onWater==true){
                if(Physics.BoxCast(transform.position+new Vector3(0,3,0), dat.transform.lossyScale/1.5f, new Vector3(0,-1,0), out RaycastHit hit2, transform.rotation, 4,~layerMask)){
                    if(hit2.transform.gameObject.CompareTag("water")){
                        if(brickCount>2){
                            //đặt gạch để đi trên nước
                            changeBrick(-1);
                            placeBridge();
                            //transform.position+=new Vector3(0,1f,0);
                            onWater=false;
                     }
                    else if(brickCount<3){
                    //nhay them 1 doan ngan, neu cham duong thi song ko thì thua
                        Vector3 direction = transform.forward;
                        direction+=new Vector3(0,-0.4f,0);
                        //Debug.Log(direction);
                        Debug.DrawRay(transform.position+new Vector3(0,1,0),direction);
                        RaycastHit hit;
                        if (Physics.Raycast(transform.position+new Vector3(0,1,0),direction, out hit, 130)){
                            
                            if( (hit.transform.gameObject.CompareTag("ground")) || (hit.transform.gameObject.CompareTag("bonus"))){
                                onWater=false;
                                transform.position=hit.point;
                            }else if(hit.transform.gameObject.CompareTag("water") ){
                                
                                Debug.Log("endgame");
                                dead();
                            }
                        }else{
                            Debug.Log("endgame");
                            dead();
                        }
                    }
                } 
                }
            }
                //destroy
            if(RemainTime<0){
                RemainTime=0;
                canKill=true;
            }else if(canKill==false)
                RemainTime-=Time.deltaTime;
            if(RemainTime < cooldown - timeGetHit)
                isKilling=false;
            if((canKill==true) && (brickCount>1))
                kill();
        }
    
    }

    //tang giam gacho.j,.
    public void changeBrick(int i){
        brickCount+=i;
        if(brickCount<=2) {
            brickCount=2;
            brick.transform.localScale = new Vector3(0.0023f,0.023f,0.0023f);
            brick.transform.localPosition  = new Vector3(-0.009f, stickPos.y, stickPos.z);
             fov.viewRadius=brickCount * 0.71f + 5;
            //Debug.Log("after"+brick.transform.position);
            return;
        }else{
        stickPos=brick.transform.localPosition;
            brick.transform.localScale += new Vector3(0f, .0123f*i*0.71f, 0f);
            brick.transform.localPosition  = new Vector3(stickPos.x-0.0123f*i*0.355f, stickPos.y, stickPos.z);
            fov.viewRadius=brickCount * 0.71f + 5;
        //else if(brickCount<0.1f)
            //brick.transform.localScale = new Vector3(0,0,0);
        }
    }
    //dat cau
    public void placeBridge(){

        lastBridgePos=transform.position;
        lastBridgePos.y=mapYPos;// - 0.055f;
        float rotateAngle= Vector3.SignedAngle(transform.forward, Vector3.forward, Vector3.down);
        Instantiate (dat,lastBridgePos, Quaternion.Euler(new Vector3(0, rotateAngle, 0)));
        this.transform.position=lastBridgePos + new Vector3(0,0.055f,0); ;
    
    }
    public virtual void kill(){
        //if( (pmove.direction.magnitude<0.1f) ){
        if(!Input.GetMouseButton(0)){
            foreach(var x in fov.visibleTargets)
            if(x!=null) {
                if((x.gameObject.CompareTag("other")) && (!x.GetComponent<player>().isHit) && (canKill) && (x.GetComponent<player>().brickCount>2) ){
                    
                    x.gameObject.GetComponent<player>().isHit=true;
                    isKilling=true;
                    canKill=false;
                    RemainTime=cooldown;
                }

            }

        }    
    }
    public virtual void dead(){
        if(passGoal){
            pmove.ani.SetInteger("end",1);
            int rank = GameObject.FindWithTag("goal").GetComponent<goal>().rank;
            gameController.endGame(rank);
        }else{
            pmove.ani.SetInteger("end",-1);
            gameController.GameOver();
        }
    }
    public virtual IEnumerator  ishit(){
        
        //if(pmove.speed!=0)
        for(int i=0;i<brickCount-2;i++){
            //changeBrick(-1);
            Instantiate (gach,transform.position+new Vector3(-0.2f,3,0), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        changeBrick(-brickCount);
        pmove.speed=0;
        yield return new WaitForSeconds(timeGetHit);
        pmove.speed=oldspeed2;
        isHit=false;
        
    }
    
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("obstacle")){
             this.gameObject.GetComponent<Rigidbody>().constraints &= ~(RigidbodyConstraints.FreezePositionX|RigidbodyConstraints.FreezePositionZ);
        }
    }
    private void OnCollisionExit(Collision other) {
        if(other.gameObject.CompareTag("obstacle")){
             this.gameObject.GetComponent<Rigidbody>().constraints |= (RigidbodyConstraints.FreezePositionX|RigidbodyConstraints.FreezePositionZ);
        }
    }
}
