using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PracEC : MonoBehaviour
{
    public Text problem;
    public Text currentFormula;
    public Text fullFormula;
    public Eq currentEquation;
    public Eq substitutions;
    public Eq substitutionc;
    public GameObject[] PracTranss;
    public GameObject[] ToolCards;
    public Eq answer;
    public PracManager pm;
    public bool trans;
    public int transAnswer;
    public int toolAnswer;
    public int m;
    public int n;
    public bool starAvailable=true;
    public bool yexist;
    public bool isy;
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
        m = Random.Range(2,10);
        n = Random.Range(2,10);
        Eq[] probs = {
        new Eq("d", new Eq("^", new Eq("e"), new Eq("sin", new Eq("^", new Eq("x"), new Eq(m.ToString()))))),
        new Eq("d", new Eq("^", new Eq("e"), new Eq(" \\times ", new Eq(n.ToString()), new Eq("x")))),
        new Eq("d", new Eq("+", new Eq("^", new Eq("x"), new Eq(m.ToString())), new Eq("^", new Eq("e"), new Eq("sin", new Eq("y"))))),
        new Eq("d", new Eq("^", new Eq("sin", new Eq("x")), new Eq(m.ToString()))),
        new Eq("d", new Eq("^", new Eq("+", new Eq("x"), new Eq("sin", new Eq("y"))), new Eq(m.ToString()))),
        new Eq("d", new Eq("+", new Eq("cos", new Eq("x")), new Eq("sin", new Eq("y")))),
        new Eq("d", new Eq("cos", new Eq("sin", new Eq("x")))),
        new Eq("d", new Eq("+", new Eq("cos", new Eq("x")), new Eq("y"))),
        new Eq("d", new Eq(" \\times ", new Eq(n.ToString()), new Eq("^", new Eq("x"), new Eq(m.ToString())))),
        new Eq("d", new Eq(" \\times ", new Eq("^", new Eq("e"), new Eq("x")), new Eq("cos", new Eq("y")))),
        new Eq("d", new Eq(" \\times ", new Eq(n.ToString()), new Eq("x"))),
        new Eq("d", new Eq(" \\times ", new Eq("x"), new Eq("y"))),
        new Eq("d", new Eq("+", new Eq("x"), new Eq("^", new Eq("e"), new Eq(" \\times ", new Eq(n.ToString()), new Eq("y"))))),
        new Eq("d", new Eq("^", new Eq("e"), new Eq(" \\times ", new Eq("x"), new Eq("sin", new Eq("y"))))),
        new Eq("d", new Eq(" \\times ", new Eq(n.ToString()), new Eq("^", new Eq("x"), new Eq(m.ToString())))),
        new Eq("d", new Eq("^", new Eq("e"), new Eq(" \\times ", new Eq("sin", new Eq("x")), new Eq("cos", new Eq("y"))))),
        new Eq("d", new Eq(" \\times ", new Eq(" \\times ", new Eq(n.ToString()), new Eq("sin", new Eq("x"))), new Eq("^", new Eq("e"), new Eq("y")))),
        new Eq("d", new Eq("^", new Eq("e"), new Eq("cos", new Eq(" \\times ", new Eq("^", new Eq("x"), new Eq(m.ToString())), new Eq("y"))))),
        new Eq("d", new Eq("^", new Eq("x"), new Eq(m.ToString()))),
        new Eq("d", new Eq(" \\times ", new Eq(n.ToString()), new Eq("^", new Eq("x"), new Eq(m.ToString()))))
        };
        Eq prob = probs[Random.Range(0, probs.Length)];
        yexist = prob.print().Contains("y");
        currentFormula.text = prob.print();
        fullFormula.text = prob.print();
        currentEquation = prob;
        trans = true;
        starAvailable = true;
        SetPracTranss();
        SetTools();
    }
    void SetPracTranss()
    {
        List<Eq> cards = currentEquation.operand1.split();
        foreach(Eq x in cards){
            Debug.Log(x.print());
        }
        for(int i=0; i < Mathf.Min(cards.Count-1, 5); i++){
            PracTranss[i].GetComponent<PracTrans>().eq = cards[i+1];
            PracTranss[i].GetComponent<PracTrans>().setEq();
        }
        for(int i=Mathf.Min(cards.Count-1, 5); i < 5; i++){
            PracTranss[i].GetComponent<PracTrans>().eq = new Eq("");
            PracTranss[i].GetComponent<PracTrans>().setEq();
        }
        if(yexist){
            if(Random.Range(0,1)<0.5f){
                answer = new Eq("d", new Eq("x"));
                isy=false;
            }else{
                answer = new Eq("d", new Eq("y"));
                isy=true;
            }
        }else{
            answer = new Eq("d", cards[Random.Range(1, cards.Count)]);
        }
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
        
        currentEquation = currentEquation.dsubstitute(eq, new Eq(symbol));
        currentFormula.text = currentEquation.print();
        fullFormula.text += "\n" + currentEquation.print();
        //SetTools();
    }
    public void SetTools(){
        string z, nz;
        if(isy){
            z = "y";
            nz = "x";
        }else{
            z = "x";
            nz = "y";
        }
        ToolCards[0].GetComponent<PracTools>().tool = new Tool(new Eq("d", new Eq("^", new Eq("e"), new Eq("★"))),new Eq(" \\times ", new Eq("^", new Eq("e"), new Eq("★")), new Eq("d", new Eq("★"))));
        ToolCards[0].GetComponent<PracTools>().setTool();
        ToolCards[1].GetComponent<PracTools>().tool = new Tool(new Eq("d", new Eq("sin", new Eq("★"))),new Eq(" \\times ", new Eq("cos", new Eq("★")), new Eq("d", new Eq("★"))));
        ToolCards[1].GetComponent<PracTools>().setTool();
        ToolCards[2].GetComponent<PracTools>().tool = new Tool(new Eq("d", new Eq("cos", new Eq("★"))),new Eq(" \\times ", new Eq("-sin", new Eq("★")), new Eq("d", new Eq("★"))));
        ToolCards[2].GetComponent<PracTools>().setTool();
        ToolCards[3].GetComponent<PracTools>().tool = new Tool(new Eq("d", new Eq("^", new Eq("★"), new Eq(m.ToString()))),new Eq(" \\times ", new Eq(m.ToString()), new Eq(" \\times ", new Eq("^", new Eq("★"), new Eq((m-1).ToString())), new Eq("d", new Eq("★")))));
        ToolCards[3].GetComponent<PracTools>().setTool();
        ToolCards[4].GetComponent<PracTools>().tool = new Tool(new Eq("d", new Eq(" \\times ", new Eq(n.ToString()), new Eq("★"))),new Eq(" \\times ", new Eq(n.ToString()), new Eq("d", new Eq("★"))));
        ToolCards[4].GetComponent<PracTools>().setTool();
        ToolCards[5].GetComponent<PracTools>().tool = new Tool(new Eq("d", new Eq("+", new Eq("★"), new Eq("◎"))),new Eq("+", new Eq("d", new Eq("★")), new Eq("d", new Eq("◎"))));
        ToolCards[5].GetComponent<PracTools>().setTool();
        ToolCards[6].GetComponent<PracTools>().tool = new Tool(new Eq("d", new Eq(" \\times ", new Eq("★"), new Eq("◎"))),new Eq("+", new Eq(" \\times ", new Eq("◎"), new Eq("d", new Eq("★"))), new Eq(" \\times ", new Eq("★"), new Eq("d", new Eq("◎")))));
        ToolCards[6].GetComponent<PracTools>().setTool();
        ToolCards[7].GetComponent<PracTools>().tool = new Tool(new Eq("d", new Eq(nz)),new Eq("\\times ", new Eq("/", new Eq("d", new Eq(nz)), new Eq("d", new Eq(z))), new Eq("d", new Eq(z))));
        ToolCards[7].GetComponent<PracTools>().setTool();
    }
    public void unsubstitute(Eq eqbefore, Eq eqafter){
        string prevEq = currentEquation.print();
        eqafter = eqafter.substitute(new Eq("★"), substitutions);
        eqafter = eqafter.substitute(new Eq("◎"), substitutionc);
        currentEquation = currentEquation.substitute(eqbefore, eqafter);
        if(!prevEq.Equals(currentEquation.print())){
            currentEquation =currentEquation.substitute(new Eq("◎"), new Eq("★"));
            substitutions = substitutionc;
            starAvailable=true;
            currentFormula.text = currentEquation.print();
            fullFormula.text += "\n" + currentEquation.print();
            if(yexist){
                if(eqbefore.print().Contains("x")||eqbefore.print().Contains("y")){
                    if(currentEquation.find(answer)){
                        pm.ProbSolved();
                        pm.transGlow.SetActive(false);
                        for(int i=0;i<5;i++){
                            PracTranss[i].GetComponent<PracTrans>().eq = new Eq("");
                            PracTranss[i].GetComponent<PracTrans>().setEq();
                        }
                    }
                }
            }else if(currentEquation.find(answer)){
                pm.ProbSolved();
                pm.transGlow.SetActive(false);
                for(int i=0;i<5;i++){
                    PracTranss[i].GetComponent<PracTrans>().eq = new Eq("");
                    PracTranss[i].GetComponent<PracTrans>().setEq();
                }
            }else{
                pm.transGlow.SetActive(true);
            }
        }else{
            pm.ProbFailed();
        }
    }
}
