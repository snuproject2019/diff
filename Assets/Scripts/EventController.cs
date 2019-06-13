using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventController : MonoBehaviour
{
    public Text problem;
    public Text currentFormula;
    public Text fullFormula;
    public Eq currentEquation;
    public Eq substitutions;
    public Eq substitutionc;
    public GameObject[] TransCards;
    public GameObject[] ToolCards;
    public Eq answer;
    public GameManager gm;
    public bool trans;
    public int transAnswer;
    public int toolAnswer;
    public bool starAvailable=true;
    // Start is called before the first frame update
    void Start()
    {
        //CreateProblem();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateProblem()
    {
        Eq prob = new Eq("d", new Eq("^", new Eq("e"), new Eq("sin", new Eq("^", new Eq("x"), new Eq("2")))));
        //Eq prob = new Eq("d", new Eq("^", new Eq("e"), new Eq("*", new Eq("3"), new Eq("x"))));
        //Eq prob = new Eq("d", new Eq("+", new Eq("^", new Eq("x"), new Eq("2")), new Eq("^", new Eq("e"), new Eq("sin", new Eq("x")))));


        currentFormula.text = prob.print();
        fullFormula.text = prob.print();
        currentEquation = prob;
        trans = true;
        SetTransCards();
    }
    void SetTransCards()
    {
        List<Eq> cards = currentEquation.operand1.split();
        foreach(Eq x in cards){
            Debug.Log(x.print());
        }
        for(int i=0; i < Mathf.Min(cards.Count-1, 5); i++){
            TransCards[i].GetComponent<TransCard>().eq = cards[i+1];
            TransCards[i].GetComponent<TransCard>().setEq();
        }
        answer = new Eq("d", cards[Random.Range(1, cards.Count)]);
        problem.text = currentFormula.text + "= ?  " + answer.print();

    }
    public void substitutex(Eq eq){
        string symbol;
        if(starAvailable){
            symbol = "★";
            starAvailable = false; 
            substitutions = eq;
        }else{
            symbol = "◎";
            substitutionc = eq;
        }
        
        currentEquation = currentEquation.substitute(eq, new Eq(symbol));
        currentFormula.text = currentEquation.print();
        fullFormula.text += "\n" + currentEquation.print();
        SetTools();
    }
    public void SetTools(){
        ToolCards[0].GetComponent<ToolSelect>().tool = new Tool(new Eq("d", new Eq("^", new Eq("e"), new Eq("★"))),new Eq("*", new Eq("^", new Eq("e"), new Eq("★")), new Eq("d", new Eq("★"))));
        ToolCards[0].GetComponent<ToolSelect>().setTool();
        ToolCards[1].GetComponent<ToolSelect>().tool = new Tool(new Eq("d", new Eq("sin", new Eq("★"))),new Eq("*", new Eq("cos", new Eq("★")), new Eq("d", new Eq("★"))));
        ToolCards[1].GetComponent<ToolSelect>().setTool();
        ToolCards[2].GetComponent<ToolSelect>().tool = new Tool(new Eq("d", new Eq("^", new Eq("★"), new Eq("2"))),new Eq("*", new Eq("2"), new Eq("*", new Eq("x"), new Eq("d", new Eq("★")))));
        ToolCards[2].GetComponent<ToolSelect>().setTool();
        ToolCards[3].GetComponent<ToolSelect>().tool = new Tool(new Eq("d", new Eq("*", new Eq("3"), new Eq("★"))),new Eq("*", new Eq("3"), new Eq("d", new Eq("★"))));
        ToolCards[3].GetComponent<ToolSelect>().setTool();
        ToolCards[4].GetComponent<ToolSelect>().tool = new Tool(new Eq("d", new Eq("+", new Eq("★"), new Eq("◎"))),new Eq("+", new Eq("d", new Eq("★")), new Eq("d", new Eq("◎"))));
        ToolCards[4].GetComponent<ToolSelect>().setTool();
    }
    public void unsubstitute(Eq eqbefore, Eq eqafter){
        string prevEq = currentEquation.print();
        eqafter = eqafter.substitute(new Eq("★"), substitutions);
        eqafter = eqafter.substitute(new Eq("◎"), substitutionc);
        currentEquation = currentEquation.substitute(eqbefore, eqafter);
        if(!prevEq.Equals(currentEquation.print())){
            starAvailable=true;
        }
        currentFormula.text = currentEquation.print();
        fullFormula.text += "\n" + currentEquation.print();
        if(currentEquation.find(answer)){
            gm.ProbSolved();
            //currentFormula.text = "";
            //fullFormula.text = "";
            //problem.text = "";
            for(int i=0;i<5;i++){
                TransCards[i].GetComponent<TransCard>().eq = new Eq("");
                TransCards[i].GetComponent<TransCard>().setEq();
            }
        }else{
            gm.transGlow.SetActive(true);
        }
    }
}
