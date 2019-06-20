using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterBook : MonoBehaviour
{
    // Start is called before the first frame update
    public List<int> monsters;
    public int curPage;
    void Start()
    {
        Set();
    }
    public void Set(){
        monsters = MyData.monsters;
        for(int i=0; i<32; i++){
            GameObject card = GameObject.Find("Card ("+(32*curPage+i)+")");
            Debug.Log((32*curPage+i));
            if(monsters.Exists(x=>x==i)){
                Debug.Log(card);
                card.GetComponent<Image>().sprite = Resources.Load<Sprite>("characters/character-"+(32*curPage+i+1));
            }else{
                card.GetComponent<Image>().sprite = Resources.Load<Sprite>("unknown");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pageUp(){
        curPage= (curPage+1)%4;
        for(int i=0; i<32; i++){
            GameObject card = GameObject.Find("Card ("+i+")");
            if(monsters.Exists(x=>x==32*curPage+i)){
                card.GetComponent<Image>().sprite = Resources.Load<Sprite>("characters/character-"+(32*curPage+i+1));
            }else{
                card.GetComponent<Image>().sprite = Resources.Load<Sprite>("unknown");
            }
        }
    }
    public void pageDown(){
        curPage= (curPage+3)%4;
        for(int i=0; i<32; i++){
            GameObject card = GameObject.Find("Card ("+(32*curPage+i)+")");
            if(monsters.Exists(x=>x==i)){
                card.GetComponent<Image>().sprite = Resources.Load<Sprite>("characters/character-"+(32*curPage+i+1));
            }else{
                card.GetComponent<Image>().sprite = Resources.Load<Sprite>("unknown");
            }
        }
    }
    public void Close(){
        gameObject.SetActive(false);
    }
}
