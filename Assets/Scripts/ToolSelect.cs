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
        Debug.Log(EC.currentEquation.print());
        if(tool.lhs.equals(EC.currentEquation.dpart())){
            EC.unsubstitute(tool.rhs);
        }
    }
}
