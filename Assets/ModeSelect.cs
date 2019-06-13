using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Close(){
        gameObject.SetActive(false);
    }
    public void GameMode(){
        SceneManager.LoadScene("Play");        
    }
    public void PracMode(){
        SceneManager.LoadScene("Prac");
    }
}
