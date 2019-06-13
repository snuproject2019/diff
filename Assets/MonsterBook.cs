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
        monsters.Add(1);
        monsters.Add(85);
        monsters.Add(120);
        monsters.Add(37);
        monsters.Add(91);
        monsters.Add(100);
        monsters.Add(26);
        monsters.Add(55);
        monsters.Add(88);
        for(int i=0; i<32; i++){
            GameObject card = GameObject.Find("Card ("+(32*curPage+i)+")");
            if(monsters.Exists(x=>x==i)){
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
}
