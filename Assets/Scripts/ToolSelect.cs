using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public Tool tool;
    public Text text;
    public EventController EC;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setTool(){
        text.text = tool.print();
    }
    public void unsubstitute(){
        if(EC.gm.myTurn && !EC.gm.solved){
            EC.unsubstitute(tool.lhs, tool.rhs);
        }
    }
}
