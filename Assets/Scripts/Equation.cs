using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Equation : MonoBehaviour
{
    public Eq eq;
    public void set(Eq eq){
        this.eq = eq;
    }
    public void Start(){
        Eq  res= new Eq("^", new Eq("e"), new Eq("sin", new Eq("^", new Eq("x"), new Eq("2"))));
        res.substitute(new Eq("sin(^(x,2))"));
        Debug.Log(res.print());
        foreach(Eq x in res.split()){
            //Debug.Log(x.value);
        }
    }
}

public class Eq{
    public string operat;
    public Eq operand1;
    public Eq operand2;
    public string value;
    public Eq(string t, Eq op1, Eq op2){
        this.operat = t;
        this.operand1 = op1;
        this.operand2 = op2;
        value =  operat + "(" + operand1.print() + "," + operand2.print() + ")"; 
    }
    public Eq(string t, Eq op1){
        this.operat = t;
        this.operand1 = op1;
        this.operand2 = new Eq("");
        value =  operat + "(" + operand1.print() + ")"; 
    }
    public Eq(string t){
        value = t;
        this.operat = "";
    }
    public string print(){
        return value;
    }
    public List<Eq> split(){
        List<Eq> res = new List<Eq>();
        res.Add(this);
        if(this.operat==""){
            ;
        }else{
            if(operand1.split().Exists(x=>x.value.Equals("x"))){
                foreach(Eq x in operand1.split()){
                    res.Add(x);
                }
            }
            if(operand2.split().Exists(x=>x.value.Equals("x"))){
                foreach(Eq x in operand2.split()){
                    res.Add(x);
                }
            }
        }
        return res;
    }
    public bool equals(Eq e){
        return this.value.Equals(e.value);
    }
    public void substitute(Eq e){
            if(this.operat!=""){
                if(operand1.value==e.value){
                this.operand1 = new Eq("☆");
                if(operand2.value!=""){
                    this.value =  operat + "(" + operand1.print() + "," + operand2.print() + ")";
                }else{
                    this.value =  operat + "(" + operand1.print() + ")";
                }
                
            }else{
                operand1.substitute(e);
            }
            
            if(operand2.value==e.value){
                this.operand2 = new Eq("☆");
                this.value =  operat + "(" + operand1.print() + "," + operand2.print() + ")";
            }else{
                operand2.substitute(e);
            }
        }   
    }
}

public class Tool{
    public Eq lhs;
    public Eq rhs;
    public Tool(Eq lhs, Eq rhs){
        this.lhs=lhs;
        this.rhs=rhs;
    }
    public string print(){
        return lhs.print() + " = " + rhs.print();
    }
}
