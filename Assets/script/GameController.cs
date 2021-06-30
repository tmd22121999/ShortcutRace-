using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class GameController : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public GameObject map, menu, cur, pre,bonus;
    public int State; 
    private void Start() {
    }
    public void GameOver() {
        gameOverText.gameObject.SetActive(true); 
        Time.timeScale = 0;
    }
    public void enterMap(){
        cur.SetActive(false);
        pre=cur;
        cur=map;
        cur.SetActive(true);  
    }
    public void startGame(int i){

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
}
