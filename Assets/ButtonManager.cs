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
    public GameObject SoundOnButton;
    public GameObject SoundOffButton;
    public SoundManager soundManager;
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
            soundManager.play(soundManager.attack);
        }
    }
    public void Recover(){
        if(gameManager.myTurn && gameManager.solved){
            gameManager.Recover();
            soundManager.play(soundManager.recover);
        }
    }
    public void Defend(){
        if(gameManager.myTurn && gameManager.solved){
            gameManager.Defend();
            soundManager.play(soundManager.defend);
        }
    }
    public void ToTitle(){
        clear.SetActive(false);
        gameOver.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void Next(){
        clear.SetActive(false);
        gameOver.SetActive(false);
        gameManager.NewGame();
    }
    public void SaveCard(){
        if(gameManager.myTurn && gameManager.solved){
            gameManager.SaveCard();
            soundManager.play(soundManager.cardAdd);
        }
    }
    public void LoadCard(){
        if(gameManager.myTurn && gameManager.solved){
            gameManager.LoadCard();
            soundManager.play(soundManager.cardRemove);
        }
    }
    public void SoundOn(){
        gameObject.GetComponent<AudioSource>().mute = false;
        SoundOnButton.SetActive(false);
        SoundOffButton.SetActive(true);
    }
    public void SoundOff(){
        gameObject.GetComponent<AudioSource>().mute = true;
        SoundOnButton.SetActive(true);
        SoundOffButton.SetActive(false);
    }
}
