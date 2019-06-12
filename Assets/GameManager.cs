using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Monster yourMonster;
    public Monster myMonster;
    public AniController AniManager;
    public bool myTurn;
    public int charged;
    public EventController ec;
    public bool solved = false;
    // Start is called before the first frame update
    void Start()
    {
        NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NewGame(){
        InitOpponent();
        InitMe();
        AniManager.VsAppear();
        myTurn = true;
    }

    void InitOpponent(){
        yourMonster.GetComponent<Image>().sprite = Resources.Load<Sprite>("characters/character-"+Random.Range(1,128));
        Color tmp = yourMonster.GetComponent<Image>().color;
        tmp.a = 255f;
        yourMonster.GetComponent<Image>().color = tmp;
        yourMonster.hp = 100;
        yourMonster.level = 5;
    }
    void InitMe(){
        myMonster.GetComponent<Image>().sprite = Resources.Load<Sprite>("characters/character-"+Random.Range(1,128));
        Color tmp = yourMonster.GetComponent<Image>().color;
        tmp.a = 255f;
        myMonster.GetComponent<Image>().color = tmp;
        myMonster.hp = 100;
        myMonster.level = 12;
    }
    public void ChangeTurn(){
        solved=false;
        myTurn = !myTurn;
        if(!myTurn){
            MonsterTime();
        }
    }
    public void Attack(){
        int dmg = 0;
        int adder = 0;
        if(myTurn){
            AniManager.YouAttack();
            if(myMonster.level > yourMonster.level){
                adder = (myMonster.level-yourMonster.level)*3;
            }else{
                adder = -(myMonster.level-yourMonster.level)*3;
            }
            switch(charged){
                    case 0:
                        dmg = 0;
                    break;
                    case 1:
                        dmg = 10+adder;
                    break;
                    case 2:
                        dmg = 10+adder*3;
                    break;
                    case 3:
                        dmg = 10+adder*5;
                    break;
            }
            yourMonster.hp -= Mathf.Max(dmg-yourMonster.shield, 0);
            yourMonster.shield = 0;
            AniManager.YouShieldBreak();
            if(yourMonster.hp<=0){
                Win();
            }else{
                ChangeTurn();
            }
        }else{
            AniManager.MeAttack();
            if(myMonster.level > yourMonster.level){
                adder = (myMonster.level-yourMonster.level)*3;
            }else{
                adder = -(myMonster.level-yourMonster.level)*3;
            }
            dmg = 10+adder;
            myMonster.hp -= Mathf.Max(dmg-myMonster.shield, 0);
            myMonster.shield = 0;
            AniManager.MeShieldBreak();
            if(myMonster.hp<=0){
                Lose();
            }else{
                ChangeTurn();
            }
        }
    }
    
    public void Recover(){
        if(myTurn){
            AniManager.MeHeal();
            myMonster.hp += (10+myMonster.level)*charged;
            if(myMonster.hp>100)myMonster.hp=100;
        }else{
            AniManager.YouHeal();
            yourMonster.hp += 10+yourMonster.level;
            if(yourMonster.hp>100)yourMonster.hp=100;
        }
        ChangeTurn();
    }
    public void Defend(){
        if(myTurn){
            AniManager.MeShield();
            int adder;
            int shield = 0;
            if(myMonster.level > yourMonster.level){
                adder = (myMonster.level-yourMonster.level)*3;
            }else{
                adder = -(myMonster.level-yourMonster.level)*3;
            }
            switch(charged){
                    case 0:
                        shield = 0;
                    break;
                    case 1:
                        shield = 10+adder;
                    break;
                    case 2:
                        shield = 10+adder*3;
                    break;
                    case 3:
                        shield = 10+adder*5;
                    break;
            }
            myMonster.shield = shield; 
        }else{
            AniManager.YouShield();
            yourMonster.shield = 10+(yourMonster.level-myMonster.level)*3;
        }
        ChangeTurn();
    }
    public void MonsterTime(){
        StartCoroutine(MonsterTimeWait());
    }
    IEnumerator MonsterTimeWait(){
        yield return new WaitForSeconds(1.5f);
        float[] prob = {0.3f, 0.7f, 1f};
        float sel = Random.Range(0,1f);
        if(sel<prob[0]){
            Attack();
        }else if(sel<prob[1]){
            Recover();
        }else{
            Defend();
        }
    }
    public void Win(){
        NewGame();
    }
    public void Lose(){
        NewGame();
    }
    public void ProbSolved(){
        solved=true;
    }
    public void ProbFailed(){
        AniManager.Wrong();
        ChangeTurn();
        ec.CreateProblem();
    }
}
