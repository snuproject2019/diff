using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOver : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter() {
        Color tmp = gameObject.GetComponent<Image>().color;
        tmp.a = 255f;
        gameObject.GetComponent<Image>().color = tmp;
    }
    private void OnMouseExit() {
        Color tmp = gameObject.GetComponent<Image>().color;
        tmp.a = 0f;
        gameObject.GetComponent<Image>().color = tmp;
    }
}
