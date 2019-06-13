using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    public GameObject clear;
    public GameObject gameOver;
    public GameObject monsterSelect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack(){
        if(gameManager.myTurn && gameManager.solved){
            gameManager.Attack();
        }
    }
    public void Recover(){
        if(gameManager.myTurn && gameManager.solved){
            gameManager.Recover();
        }
    }
    public void Defend(){
        if(gameManager.myTurn && gameManager.solved){
            gameManager.Defend();
        }
    }
    public void ToTitle(){
        clear.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void Next(){
        clear.SetActive(false);
        gameManager.NewGame();
    }
    public void SaveCard(){
        if(gameManager.myTurn && gameManager.solved){
            gameManager.SaveCard();
        }
    }
    public void LoadCard(){
        if(gameManager.myTurn && gameManager.solved){
            gameManager.LoadCard();
        }
    }
}
