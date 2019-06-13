using UnityEngine;
using System.Collections;

public class Tester : MonoBehaviour {

    [SerializeField] string curformula;
    [SerializeField] string probformula;
    [SerializeField] string totformula;
    [SerializeField] string transformula1;
    [SerializeField] string transformula2;
    [SerializeField] string transformula3;
    [SerializeField] string transformula4;
    [SerializeField] string transformula5;
    [SerializeField] string buttonformula1;
    [SerializeField] string buttonformula2;
    [SerializeField] string buttonformula3;
    [SerializeField] string buttonformula4;
    [SerializeField] string buttonformula5;

    Texture texture1=null;
    Texture texture2=null;
    Texture texture3=null;
    Texture texture4=null;
    Texture texture5=null;
    Texture texture6=null;
    Texture texture7=null;
    Texture texture8=null;
    Texture texture9=null;
    Texture texture10=null;
    Texture texture11=null;
    Texture texture12=null;
    Texture texture13=null;
    public UnityEngine.UI.Text tool1;
    public UnityEngine.UI.Text tool2;
    public UnityEngine.UI.Text tool3;
    public UnityEngine.UI.Text tool4;
    public UnityEngine.UI.Text tool5;
    public UnityEngine.UI.Text trans1;
    public UnityEngine.UI.Text trans2;
    public UnityEngine.UI.Text trans3;
    public UnityEngine.UI.Text trans4;
    public UnityEngine.UI.Text trans5;
    public EventController ec;
    IEnumerator Start() {
        curformula = ec.currentFormula.text;
        probformula = ec.problem.text;
        totformula = ec.fullFormula.text;
        transformula1 = tool1.text;
        transformula2 = tool2.text;
        transformula3 = tool3.text;
        transformula4 = tool4.text;
        transformula5 = tool5.text;
        buttonformula1 = trans1.text;
        buttonformula2 = trans2.text;
        buttonformula3 = trans3.text;
        buttonformula4 = trans4.text;
        buttonformula5 = trans5.text;
        WWW www1=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+curformula);
        yield return www1;
        WWW www2=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+probformula);
        yield return www2;
        WWW www3=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+totformula);
        yield return www3;
        WWW www4=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+transformula1);
        yield return www4;
        WWW www5=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+transformula2);
        yield return www5;
        WWW www6=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+transformula3);
        yield return www6;
        WWW www7=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+transformula4);
        yield return www7;
        WWW www8=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+transformula5);
        yield return www8;
        WWW www9=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+buttonformula1);
        yield return www9;
        WWW www10=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+buttonformula2);
        yield return www10;
        WWW www11=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+buttonformula3);
        yield return www11;
        WWW www12=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+buttonformula4);
        yield return www12;
        WWW www13=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+buttonformula5);
        yield return www13;
        

        
        texture1=www1.texture;
        texture2=www2.texture;
        texture3=www3.texture;
        texture4=www4.texture;
        texture5=www5.texture;
        texture6=www6.texture;
        texture7=www7.texture;
        texture8=www8.texture;
        texture9=www9.texture;
        texture10=www10.texture;
        texture11=www11.texture;
        texture12=www12.texture;
        texture13=www13.texture;
    }
    void OnGUI() {
        if(texture1 != null)
            GUI.DrawTexture(new Rect(60,240,texture1.width,texture1.height), texture1);
        if(texture2 != null)
            GUI.DrawTexture(new Rect(60,30,texture2.width,texture2.height), texture2);
        if(texture3 != null)
            GUI.DrawTexture(new Rect(60,270,texture3.width,texture3.height), texture3);
        if(texture4 != null)
            GUI.DrawTexture(new Rect(250,241,texture4.width*0.7f,texture4.height*0.7f), texture4);
        if(texture5 != null)
            GUI.DrawTexture(new Rect(250,263,texture5.width*0.7f,texture5.height*0.7f), texture5);
        if(texture6 != null)
            GUI.DrawTexture(new Rect(250,285,texture6.width*0.7f,texture6.height*0.7f), texture6);
        if(texture7 != null)
            GUI.DrawTexture(new Rect(250,307,texture7.width*0.7f,texture7.height*0.7f), texture7);
        if(texture8 != null)
            GUI.DrawTexture(new Rect(250,329,texture8.width*0.7f,texture8.height*0.7f), texture8);
        if(texture9 != null)
            GUI.DrawTexture(new Rect(23,190,texture9.width*0.7f,texture9.height*0.7f), texture9);
        if(texture10 != null)
            GUI.DrawTexture(new Rect(67,190,texture10.width*0.7f,texture10.height*0.7f), texture10);
        if(texture11 != null)
            GUI.DrawTexture(new Rect(111,190,texture11.width*0.7f,texture11.height*0.7f), texture11);
        if(texture12 != null)
            GUI.DrawTexture(new Rect(155,190,texture12.width*0.7f,texture12.height*0.7f), texture12);
        if(texture13 != null)
            GUI.DrawTexture(new Rect(201,190,texture13.width*0.7f,texture13.height*0.7f), texture13);
            
    }
    public void Update(){
        StartCoroutine(k());
        
        
    }
    public IEnumerator k(){
        curformula = ec.currentFormula.text;
        probformula = ec.problem.text;
        totformula = ec.fullFormula.text;
        transformula1 = tool1.text;
        transformula2 = tool2.text;
        transformula3 = tool3.text;
        transformula4 = tool4.text;
        transformula5 = tool5.text;
        buttonformula1 = trans1.text;
        buttonformula2 = trans2.text;
        buttonformula3 = trans3.text;
        buttonformula4 = trans4.text;
        buttonformula5 = trans5.text;

        WWW www1=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+curformula);
        yield return www1;
        WWW www2=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+probformula);
        yield return www2;
        WWW www3=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+totformula);
        yield return www3;
        WWW www4=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+transformula1);
        yield return www4;
        WWW www5=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+transformula2);
        yield return www5;
        WWW www6=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+transformula3);
        yield return www6;
        WWW www7=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+transformula4);
        yield return www7;
        WWW www8=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+transformula5);
        yield return www8;
        WWW www9=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+buttonformula1);
        yield return www9;
        WWW www10=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+buttonformula2);
        yield return www10;
        WWW www11=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+buttonformula3);
        yield return www11;
        WWW www12=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+buttonformula4);
        yield return www12;
        WWW www13=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+buttonformula5);
        yield return www13;
        

        
        texture1=www1.texture;
        texture2=www2.texture;
        texture3=www3.texture;
        texture4=www4.texture;
        texture5=www5.texture;
        texture6=www6.texture;
        texture7=www7.texture;
        texture8=www8.texture;
        texture9=www9.texture;
        texture10=www10.texture;
        texture11=www11.texture;
        texture12=www12.texture;
        texture13=www13.texture;
        
    }
}