using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrace : MonoBehaviour
{
    public string entrecePassword;
    
    void Start(){
        if(Player.instance.scenePassword==entrecePassword){
            Player.instance.transform.position=transform.position;
           Debug.Log("Entrou");
        }
    }
}
