using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MyData : MonoBehaviour
{
    static public int level = 5;
    static public float exp = 0.27f;
    static public List<int> monsters = new int[] {0}.ToList();
    // Start is called before the first frame update
    void Start()
    {
        monsters = new List<int>();
        monsters.Add(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    static public void setData(int l, float e, string m){
        level = l;
        exp = e;
        monsters = new List<int>();
        foreach (string k in m.Split(',').ToList())
        {
            monsters.Add(int.Parse(k));
        };
        if(monsters.Count==0){
            monsters.Add(0);
        }
    }
    static public string getMonsters(){
        List<string> mm = new List<string>();
        foreach(int k in monsters){
            mm.Add(k.ToString());
        }
        return string.Join(",", mm.ToArray());
    }
}
