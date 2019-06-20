using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TexUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TEXDraw>().text = gameObject.transform.parent.GetChild(1).gameObject.GetComponent<Text>().text;
    }
}
