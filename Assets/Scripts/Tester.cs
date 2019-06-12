using UnityEngine;
using System.Collections;

public class Tester : MonoBehaviour {

    [SerializeField] string formula=@"\displaystyle\int_{-\infty}^{\infty}e^{-x^{2}}\;dx=\sqrt{\pi}";
    Texture texture=null;
    public EventController ec;
    IEnumerator Start() {
        WWW www=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+formula);
        yield return www;
        texture=www.texture;
    }
    void OnGUI() {
        if(texture != null)
            GUI.DrawTexture(new Rect(60,240,texture.width,texture.height), texture);
    }
    public void Update(){
        StartCoroutine(k());
        
        
    }
    public IEnumerator k(){
        formula = ec.currentEquation.print();
        WWW www=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+formula);
        yield return www;
        texture=www.texture;
        
    }
}