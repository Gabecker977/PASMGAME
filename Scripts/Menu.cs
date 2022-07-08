using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Menu : MonoBehaviour
{
  //  public Sprite[] player1;
  //  public GameObject image;
    
    public void PlayGame(){
        EditorSceneManager.LoadScene("Level00");
    }

    public void CharacterMenu(){
      // image.GetComponent<Image>();
    }
    public void Close(){
        Debug.Log("Saiu");
        Application.Quit();
    }
}
