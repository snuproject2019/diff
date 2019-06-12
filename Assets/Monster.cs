using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    public float hp;
    public Image hpLeft;
    public int level;
    public int shield = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp<=0){
            hpLeft.transform.localScale = new Vector3(0, 1, 1);
        }else{
            hpLeft.transform.localScale = new Vector3(hp/100, 1, 1);
        }
        
    }
}
