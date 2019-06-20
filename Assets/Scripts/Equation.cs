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
    }
}

public class Eq{
    public string operat;
    public Eq operand1;
    public Eq operand2;
    public Eq(string t, Eq op1 = null, Eq op2 = null){
        this.operat = t;
        this.operand1 = op1;
        this.operand2 = op2;
    }
    public string print(){
        if(operand2!=null){
            if(operat.Equals("/")){
                return "\\frac "+ "{" + operand1.print() + "} {" + operand2.print() + "}";
            }
            return "{{" + operand1.print() + "}" + operat + "{" + operand2.print() + "}}";
        }else if(operand1!=null){
            return operat + "{(" + operand1.print() + ")}";
        }else{
            return operat;
        }
    }
    public List<Eq> split(){
        List<Eq> res = new List<Eq>();
        res.Add(this); 
        if(this.operat==""){
            ;
        }else{
            if(operand1!=null){
                if(operand1.split().Exists(x=>(x.print().Equals("x")||x.print().Equals("y")))){
                    foreach(Eq x in operand1.split()){
                        res.Add(x);
                    }
                }
            }
            if(operand2!=null){
                if(operand2.split().Exists(x=>(x.print().Equals("x")||x.print().Equals("y")))){
                    foreach(Eq x in operand2.split()){
                        res.Add(x);
                    }
                }
            }
        }
        return res;
    }
    public bool equals(Eq e){
        return this.print().Equals(e.print());
    }
     
    public Eq dsubstitute(Eq e, Eq newE){
        Eq t = new Eq(this.operat, this.operand1, this.operand2);
        if(t.operat=="d"){
            return new Eq("d", operand1.substitute(e, newE));
        }else{
            if(this.operat!=""){
                if(operand1!=null){
                    if(!operand1.print().Equals(operand1.dsubstitute(e, newE).print())){
                        return new Eq(this.operat, operand1.dsubstitute(e, newE), this.operand2);
                    }
                }
                if(operand2!=null){
                    if(!operand2.print().Equals(operand2.dsubstitute(e, newE).print())){
                        return new Eq(this.operat, operand1, operand2.dsubstitute(e, newE));
                    }
                }
            }
        }
        return t;
    }
    
    public Eq dpart(){
        if(this.operat=="d"){
            return this;
        }else{
            if(operand2!=null){
                if(operand2.dpart()==null){
                    return operand1.dpart();    
                }
                return operand2.dpart();
            }else if(operand1!=null){
                return operand1.dpart();
            }else{
                return null;
            }
        }
    }
    /*
    public void dunsubstitute(Eq e){
        if(this.operat=="d"){
            operand1.unsubstitute(e);
        }else{
            if(this.operat!=""){
                operand1.dunsubstitute(e);
                if(operand2!=null){
                    operand2.dunsubstitute(e);
                }
            }
        }
        setValue();
    }
    */
    public Eq substitute(Eq e, Eq newE){
        Eq t = new Eq(this.operat, this.operand1, this.operand2);
        if(t.print()==e.print()){
            return newE;
        }
        else{
            if(operand2!=null){
                t.operand2 = t.operand2.substitute(e, newE);
            }
            if(operand1!=null){
                t.operand1 = t.operand1.substitute(e, newE);
            }
            return t;
        }
    }
    public bool find(Eq e){
        Eq t = new Eq(this.operat, this.operand1, this.operand2);
        if(t.print()==e.print()){
            return true;
        }
        else{
            if(operand2!=null){
                if(t.operand2.find(e)){
                    return true;
                };
            }
            if(operand1!=null){
                if(t.operand1.find(e)){
                    return true;
                };
            }
            return false;
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
        return lhs.print() + " \\rightarrow " + rhs.print();
    }
}
