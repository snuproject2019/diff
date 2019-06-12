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
    public Eq answer;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        CreateProblem();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateProblem()
    {
        Eq prob = new Eq("d", new Eq("^", new Eq("e"), new Eq("sin", new Eq("^", new Eq("x"), new Eq("2")))));
        //Eq prob = new Eq("d", new Eq("^", new Eq("e"), new Eq("*", new Eq("3"), new Eq("x"))));
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
        answer = new Eq("d", cards[Random.Range(1, cards.Count-1)]);
        problem.text = currentFormula.text + "= ? * " + answer.print();

    }
    public void substitutex(Eq eq){
        substitution = eq;
        Eq newD =  currentEquation.dpart();
        newD = newD.substitute(eq, new Eq("\\clubsuit"));
        currentEquation = currentEquation.substitute(currentEquation.dpart(), newD);
        currentFormula.text = currentEquation.print();
        fullFormula.text += "\n" + currentEquation.print();
        SetTools();
    }
    public void SetTools(){
        ToolCards[0].GetComponent<ToolSelect>().tool = new Tool(new Eq("d", new Eq("^", new Eq("e"), new Eq("\\clubsuit"))),new Eq("*", new Eq("^", new Eq("e"), new Eq("\\clubsuit")), new Eq("d", new Eq("\\clubsuit"))));
        ToolCards[0].GetComponent<ToolSelect>().setTool();
        ToolCards[1].GetComponent<ToolSelect>().tool = new Tool(new Eq("d", new Eq("sin", new Eq("\\clubsuit"))),new Eq("*", new Eq("cos", new Eq("\\clubsuit")), new Eq("d", new Eq("\\clubsuit"))));
        ToolCards[1].GetComponent<ToolSelect>().setTool();
        ToolCards[2].GetComponent<ToolSelect>().tool = new Tool(new Eq("d", new Eq("^", new Eq("\\clubsuit"), new Eq("2"))),new Eq("*", new Eq("2"), new Eq("*", new Eq("x"), new Eq("d", new Eq("\\clubsuit")))));
        ToolCards[2].GetComponent<ToolSelect>().setTool();
        ToolCards[3].GetComponent<ToolSelect>().tool = new Tool(new Eq("d", new Eq("*", new Eq("3"), new Eq("\\clubsuit"))),new Eq("*", new Eq("3"), new Eq("d", new Eq("\\clubsuit"))));
        ToolCards[3].GetComponent<ToolSelect>().setTool();
        ToolCards[4].GetComponent<ToolSelect>().tool = new Tool(new Eq("d", new Eq("^", new Eq("e"), new Eq("\\clubsuit"))),new Eq("*", new Eq("^", new Eq("e"), new Eq("\\clubsuit")), new Eq("d", new Eq("\\clubsuit"))));
        ToolCards[4].GetComponent<ToolSelect>().setTool();
    }
    public void unsubstitute(Eq eq){
        eq = eq.substitute(new Eq("\\clubsuit"), substitution);
        currentEquation = currentEquation.substitute(currentEquation.dpart(), eq);
        currentFormula.text = currentEquation.print();
        fullFormula.text += "\n" + currentEquation.print();
        if(currentEquation.dpart().equals(answer)){
            gm.ProbSolved();
            CreateProblem();
        }
    }
}
