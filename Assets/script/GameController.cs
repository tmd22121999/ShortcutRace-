using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public GameObject map, menu, end, cur, pre,bonus;
    public int State; 
    private void Start() {
    }
    public void GameOver(int rank, float score) {
        //gameOverText.gameObject.SetActive(true); 
        cur = end;
        cur.SetActive(true); 
        cur.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text += rank;
        cur.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text += score;
        Time.timeScale = 0;
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
}
