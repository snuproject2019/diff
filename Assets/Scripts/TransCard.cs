﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransCard : MonoBehaviour
{
    public Eq eq;
    public Text text;
    public GameObject selected;
    public EventController EC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setEq(){
        text.text = eq.print();
        selected.SetActive(false);
    }
    public void substitute(){
        if(EC.gm.myTurn && !EC.gm.solved && EC.trans){
            EC.substitutex(eq);
            selected.SetActive(true);
            EC.trans = !EC.trans;
            EC.gm.toolGlow.SetActive(true);
            EC.gm.transGlow.SetActive(false);
        }
    }
}
