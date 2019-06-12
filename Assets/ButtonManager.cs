using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
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
}
