using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{   TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text=GetComponentInChildren<TMP_Text>();
        
    }
    void Update(){
    text.SetText("Pontos: "+Player.instance.points);  
    }
    
    /*public void setPoints(float p){
        //Debug.Log(p);
    text.SetText("Pontos: "+p);    
    }*/
    
}
