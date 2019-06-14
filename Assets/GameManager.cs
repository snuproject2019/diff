using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Monster yourMonster;
    public Monster myMonster;
    public List<int> monsters;
    public AniController AniManager;
    public bool myTurn;
    public int charged = 0;
    public int saved = 0;
    public int stage;
    public int level;
    public int monsterNum;
    public int yourMonsterNum;
    public Text savedText;
    public Text lv;
    public Text ylv;
    public EventController ec;
    public float exp = 0.27f;
    public bool solved = false;
    public GameObject expleft;
    public GameObject clear;
    public GameObject gameOver;
    public GameObject monsterSelect;
    public GameObject card1selected;
    public GameObject card2selected;
    public GameObject card3selected;
    public GameObject toolGlow;
    public GameObject deckGlow;
    public GameObject transGlow;
    public Text stageText;
    // Start is called before the first frame update
    void Start()
    {
        monsters.Add(1);
        monsters.Add(85);
        monsters.Add(120);
        monsters.Add(37);
        monsters.Add(91);
        monsters.Add(100);
        monsters.Add(26);
        monsters.Add(55);
        monsters.Add(88);
        monsterNum = monsters[Random.Range(0,monsters.Count)];
        NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        switch(charged){
            case 0:
                card1selected.SetActive(false);
                card2selected.SetActive(false);
                card3selected.SetActive(false);
                break;
            case 1:
                card1selected.SetActive(true);
                card2selected.SetActive(false);
                card3selected.SetActive(false);
                break;
            case 2:
                card1selected.SetActive(true);
                card2selected.SetActive(true);
                card3selected.SetActive(false);
                break;
            case 3:
                card1selected.SetActive(true);
                card2selected.SetActive(true);
                card3selected.SetActive(true);
                break;
        }
    }

    public void NewGame(){
        solved = false;
        charged=0;
        saved=0;
        InitOpponent();
        InitMe();
        AniManager.VsAppear();
        myTurn = true;
        ec.CreateProblem();
        transGlow.SetActive(true);
        stageText.text = stage+"";
    }

    void InitOpponent(){
        yourMonsterNum = Random.Range(1,128);
        yourMonster.GetComponent<Image>().sprite = Resources.Load<Sprite>("characters/character-"+yourMonsterNum);
        Color tmp = yourMonster.GetComponent<Image>().color;
        tmp.a = 255f;
        yourMonster.GetComponent<Image>().color = tmp;
        yourMonster.hp = 100;
        yourMonster.level = Random.Range(level-4, level+2);
        ylv.text = "LV." + yourMonster.level;
    }
    void InitMe(){
        myMonster.GetComponent<Image>().sprite = Resources.Load<Sprite>("characters/character-"+monsterNum);
        Color tmp = yourMonster.GetComponent<Image>().color;
        tmp.a = 255f;
        myMonster.GetComponent<Image>().color = tmp;
        myMonster.hp = 100;
        myMonster.level = level;
        lv.text = "LV." + level;
        expleft.transform.localScale = new Vector3(exp, 1, 1);
    }
    public void ChangeTurn(){
        solved=false;
        myTurn = !myTurn;
        if(!myTurn){
            deckGlow.SetActive(false);
            MonsterTime();
        }
    }
    public void Attack(){
        int dmg = 0;
        int adder = 0;
        if(myTurn){
            AniManager.YouAttack();
            if(myMonster.level > yourMonster.level){
                adder = (myMonster.level-yourMonster.level)*2;
            }else{
                adder = (myMonster.level-yourMonster.level);
            }
            switch(charged){
                    case 0:
                        dmg = 3;
                    break;
                    case 1:
                        dmg = 15+adder;
                    break;
                    case 2:
                        dmg = (15+adder)*3;
                    break;
                    case 3:
                        dmg = (15+adder)*5;
                    break;
            }
            yourMonster.hp -= Mathf.Max(dmg-yourMonster.shield, 0);
            yourMonster.shield = 0;
            charged=0;
            AniManager.YouShieldBreak();
            if(yourMonster.hp<=0){
                Win();
            }else{
                ChangeTurn();
            }
        }else{
            AniManager.MeAttack();
            if(myMonster.level > yourMonster.level){
                adder = -(myMonster.level-yourMonster.level);
            }else{
                adder = -(myMonster.level-yourMonster.level)*2;
            }
            dmg = 15+adder;
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
            if(charged==0)myMonster.hp +=3;
            if(myMonster.hp>100)myMonster.hp=100;
            charged=0;
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
                        shield = 3;
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
            charged=0;
        }else{
            AniManager.YouShield();
            yourMonster.shield = 10+Mathf.Abs((yourMonster.level-myMonster.level))*3;
        }
        ChangeTurn();
    }
    public void MonsterTime(){
        StartCoroutine(MonsterTimeWait());
    }
    IEnumerator MonsterTimeWait(){
        yield return new WaitForSeconds(1.5f);
        float[] prob = {0.5f, 0.8f, 1f};
        float sel = Random.Range(0,1f);
        if(sel<prob[0]){
            Attack();
        }else if(sel<prob[1]){
            Recover();
        }else{
            Defend();
        }
        yield return new WaitForSeconds(1.5f);
        ec.CreateProblem();
        transGlow.SetActive(true);
    }
    public void Win(){
        stage++;
        exp = exp + Mathf.Max((50-Mathf.Log(level)*3+(Mathf.Log(yourMonster.level)-Mathf.Log(level)*6))/100,0);
        if(exp>1){
            exp = exp-1;
            level++;
        }
        if(!monsters.Exists(x=>x==yourMonsterNum)){
            monsters.Add(yourMonsterNum);
        }
        clear.SetActive(true);
    }
    public void Lose(){
        gameOver.SetActive(true);
    }
    public void ProbSolved(){
        solved=true;
        charged+=1;
        deckGlow.SetActive(true);
        AniManager.Correct();
    }
    public void ProbFailed(){
        AniManager.Wrong();
        ChangeTurn();
        ec.CreateProblem();
    }
    public void SaveCard(){
        if(charged>0){
            charged--;
            saved++;
            savedText.text = "X " + saved;
        }
        
    }
    public void LoadCard(){
        if(saved>0 && charged<3){
            charged++;
            saved--;
            savedText.text = "X " + saved;
        }
    }
}
