using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PracTools : MonoBehaviour
{
    // Start is called before the first frame update
    public Tool tool;
    public Text text;
    public PracEC EC;
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
            EC.unsubstitute(tool.lhs, tool.rhs);
            EC.trans = !EC.trans;
            EC.pm.toolGlow.SetActive(false);
        
    }
}
