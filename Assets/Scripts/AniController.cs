using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniController : MonoBehaviour
{
    public GameObject vsImage;
    public GameObject meAttack;
    public GameObject youAttack;
    public GameObject meHeal;
    public GameObject youHeal;
    public GameObject meShield;
    public GameObject youShield;
    public GameObject wrong;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void VsAppear(){
        StartCoroutine(AppearFor(vsImage, 2));
    }
    public void MeAttack(){
        StartCoroutine(AppearFor(meAttack, 0.7f));
    }
    public void YouAttack(){
        StartCoroutine(AppearFor(youAttack, 0.7f));
    }
    public void MeHeal(){
        StartCoroutine(AppearFor(meHeal, 0.7f));
    }
    public void YouHeal(){
        StartCoroutine(AppearFor(youHeal, 0.7f));
    }
    public void MeShield(){
        meShield.SetActive(true);
    }
    public void MeShieldBreak(){
        meShield.SetActive(false);
    }
    public void YouShield(){
        youShield.SetActive(true);
    }
    public void YouShieldBreak(){
        youShield.SetActive(false);
    }

    IEnumerator AppearFor(GameObject o, float seconds){
        o.SetActive(true);
        yield return new WaitForSeconds(seconds);
        o.SetActive(false);
    }
    public void Wrong(){
        StartCoroutine(AppearFor(wrong, 0.7f));
    }
}
