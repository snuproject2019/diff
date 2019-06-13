using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


public class ButtonController_Title : MonoBehaviour
{
    public GameObject HelpWindow;
    public GameObject ModeSelect;
    public GameObject SoundOnButton;
    public GameObject SoundOffButton;
    public GameObject MonsterBook;

    public void Help(){
        HelpWindow.SetActive(true);
    }    
    
    public void Book(){
        MonsterBook.SetActive(true);
    }
    public void SoundOn(){
        gameObject.GetComponent<AudioSource>().mute = false;
        SoundOnButton.SetActive(false);
        SoundOffButton.SetActive(true);
    }
    public void SoundOff(){
        gameObject.GetComponent<AudioSource>().mute = true;
        SoundOnButton.SetActive(true);
        SoundOffButton.SetActive(false);
    }
}

