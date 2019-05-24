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
    public Eq substitution;
    public GameObject[] TransCards;
    public GameObject[] ToolCards;
    // Start is called before the first frame update
    void Start()
    {
        CreateProblem();
        Eq  res= new Eq("*", new Eq("^", new Eq("e"), new Eq("sin", new Eq("^", new Eq("x"), new Eq("2")))), new Eq("d", new Eq("sin", new Eq("^", new Eq("x"), new Eq("2")))));
        Eq xx = new Eq("^", new Eq("x"), new Eq("2"));
        Debug.Log(res.print());
        Debug.Log(xx.print());
        Debug.Log(res.dpart().print());
        res.dpart().substitute(xx, new Eq("☆"));
        //res.setValue();
        Debug.Log(res.print());
        //res.dsubstitute(new Eq("sin(^(x,2))"));
        //Debug.Log(res.print());
        //res.unsubstitute(new Eq("sin(^(x,2))"));
        //Debug.Log(res.print());
        foreach(Eq x in res.split()){
            //Debug.Log(x.value);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateProblem()
    {
        //Eq prob = new Eq("d", new Eq("^", new Eq("e"), new Eq("sin", new Eq("^", new Eq("x"), new Eq("2")))));
        Eq prob = new Eq("d", new Eq("^", new Eq("e"), new Eq("*", new Eq("3"), new Eq("x"))));
        problem.text = prob.print();
        currentFormula.text = prob.print();
        fullFormula.text = prob.print();
        currentEquation = prob;
        SetTransCards();
    }
    void SetTransCards()
    {
        List<Eq> cards = currentEquation.operand1.split();
        for(int i=0; i < Mathf.Min(cards.Count-1, 5); i++){
            TransCards[i].GetComponent<TransCard>().eq = cards[i+1];
            TransCards[i].GetComponent<TransCard>().setEq();
        }

    }
    public void substitutex(Eq eq){
        substitution = eq;
        Eq newD =  currentEquation.dpart();
        newD = newD.substitute(eq, new Eq("☆"));
        currentEquation = currentEquation.substitute(currentEquation.dpart(), newD);
        currentFormula.text = currentEquation.print();
        fullFormula.text += "\n" + currentEquation.print();
        SetTools();
    }
    public void SetTools(){
        ToolCards[0].GetComponent<ToolSelect>().tool = new Tool(new Eq("d", new Eq("^", new Eq("e"), new Eq("☆"))),new Eq("*", new Eq("^", new Eq("e"), new Eq("☆")), new Eq("d", new Eq("☆"))));
        ToolCards[0].GetComponent<ToolSelect>().setTool();
        ToolCards[1].GetComponent<ToolSelect>().tool = new Tool(new Eq("d", new Eq("sin", new Eq("☆"))),new Eq("*", new Eq("cos", new Eq("☆")), new Eq("d", new Eq("☆"))));
        ToolCards[1].GetComponent<ToolSelect>().setTool();
        ToolCards[2].GetComponent<ToolSelect>().tool = new Tool(new Eq("d", new Eq("^", new Eq("☆"), new Eq("2"))),new Eq("*", new Eq("2"), new Eq("*", new Eq("x"), new Eq("d", new Eq("☆")))));
        ToolCards[2].GetComponent<ToolSelect>().setTool();
        ToolCards[3].GetComponent<ToolSelect>().tool = new Tool(new Eq("d", new Eq("*", new Eq("3"), new Eq("☆"))),new Eq("*", new Eq("3"), new Eq("d", new Eq("☆"))));
        ToolCards[3].GetComponent<ToolSelect>().setTool();
        ToolCards[4].GetComponent<ToolSelect>().tool = new Tool(new Eq("d", new Eq("^", new Eq("e"), new Eq("☆"))),new Eq("*", new Eq("^", new Eq("e"), new Eq("☆")), new Eq("d", new Eq("☆"))));
        ToolCards[4].GetComponent<ToolSelect>().setTool();
    }
    public void unsubstitute(Eq eq){
        eq = eq.substitute(new Eq("☆"), substitution);
        currentEquation = currentEquation.substitute(currentEquation.dpart(), eq);
        currentFormula.text = currentEquation.print();
        fullFormula.text += "\n" + currentEquation.print();

    }
}
