using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Help : MonoBehaviour
{
    public int curPage;
    public GameObject[] pages;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Right(){
        pages[curPage].SetActive(false);
        curPage=(curPage+1)%5;
        pages[curPage].SetActive(true);
    }
    public void Left(){
        pages[curPage].SetActive(false);
        curPage=(curPage+4)%5;
        pages[curPage].SetActive(true);
    }
    public void Close(){
        curPage=0;
        gameObject.SetActive(false);
    }
}
