using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TransCard : MonoBehaviour
{
    public Eq eq;
    public Text text;
    public GameObject selected;
    public EventController EC;
    public SoundManager soundManager;
    //public bool y;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
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
        if(!(eq==null)){
            if(!eq.print().Equals("")){
                if(EC.gm.myTurn && !EC.gm.solved){
                    EC.substitutex(eq);
                    selected.SetActive(true);
                    EC.trans = !EC.trans;
                    //EC.gm.transGlow.SetActive(false);
                    soundManager.play(soundManager.transSelect);
                }
            }
        }
    }
}
