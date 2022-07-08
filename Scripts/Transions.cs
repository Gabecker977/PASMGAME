using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Transions : MonoBehaviour
{
    BoxCollider2D trigger;
    [SerializeField]
    private string LevelName;
    public string newScenePassword;
     [SerializeField]
     private bool canOpen=true;
    void Start()
    {
        trigger=this.GetComponent<BoxCollider2D>();
    }
    
   public void OnTriggerEnter2D(Collider2D e){
     
        if(e.CompareTag("Player")&&canOpen){
        EditorSceneManager.LoadScene(LevelName);
        Player.instance.scenePassword=newScenePassword;
        }
    }
    public void OnTriggerStay2D(Collider2D e){
     if(e.CompareTag("Player")&&Input.GetKeyDown(KeyCode.E)){
        EditorSceneManager.LoadScene(LevelName);
        Player.instance.scenePassword=newScenePassword;
        }
    }
}
