using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransCard : MonoBehaviour
{
    public Eq eq;
    public Text text;
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
    }
    public void substitute(){
        EC.substitutex(eq);
    }
}
