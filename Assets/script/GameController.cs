﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    
    public GameObject map, menu, cur, pre,bonus,setting;
    public int State; 
    [Header ("End game UI")]
     public GameObject end;

     public GameObject gameOver,win,lose;
     public Image cooldown;
    public TextMeshProUGUI rankText,scoreText;
    private bool isCooldown = false;
    
    public void GameOver() {
        cur=gameOver;
        gameOver.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(revive(5));
    }
    private void Update() {
        if(isCooldown){
            cooldown.fillAmount -= (1.0f / 5.0f )*Time.unscaledDeltaTime;
        }
    }
     private IEnumerator  revive(float waitTime){
        isCooldown = true;
        yield return new WaitForSecondsRealtime(waitTime);
        endGame(7);
        
    }
    public void endGame(int rank){
        Time.timeScale = 0;
        if(cur!=null)
            cur.SetActive(false); 
        cur = end;
        cur.SetActive(true); 
        if(rank == 1){
            win.SetActive(true);
        }else{
            lose.SetActive(true);
        }
    }
    
    public void enterMap(){
        cur.SetActive(false);
        pre=menu;
        cur=map;
        cur.SetActive(true);  
    }
    public void startGame(int i){
        string map="Map"+i;
        SceneManager.LoadScene(map);
        cur.SetActive(false);
        //pre=cur;
    }
    public void back(){
        if(pre!=null){
            cur.SetActive(false);
            pre.SetActive(true);
            cur=pre;
            pre=null;

        }
    }
    public void activeBonus(){
        bonus.SetActive(true);  
    }
    public void returnMap(){
         SceneManager.LoadScene("UItest");
    }
    public void onSetting(){
        pre = menu;
        cur=setting;
        cur.SetActive(true);  
        
    }
}
