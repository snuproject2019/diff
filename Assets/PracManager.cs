using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PracManager : MonoBehaviour
{
    public AniController AniManager;
    public PracEC ec;
    public GameObject transGlow;
    public GameObject toolGlow;
    // Start is called before the first frame update
    void Start(){
        NewGame();
    }
    public void NewGame(){
        ec.CreateProblem();
    }

    public void ProbSolved(){
        AniManager.Correct();
        ec.CreateProblem();
    }
    public void ProbFailed(){
        AniManager.Wrong();
        ec.CreateProblem();
    }

}
