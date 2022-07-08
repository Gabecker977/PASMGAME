using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Quiz : Interactable
{

   
    [HideInInspector]
	public bool canInteract;
    public GameObject canvas;

    public int id;

    //[SerializeField]
    //private int difcult;
    //Animator anim;
    //QuizManeger quizManeger;
    [SerializeField]
    public int dif;
    //SortQuiz sq;
     //public List<Question> questions;

    // public static int[]answers= {2,2,2,1,1,2,1,1,2,2, 1,0,2,0,1,1,2, 2,1,1,0,1,1,1,1};
   // public int guess;
     
   // public GameObject[] buttons;
   //  int curQuestion=0;
  //  [Header("Labels")]
  //  [SerializeField]
  //  public GameObject Questionlabel;
  //  [SerializeField]
  //  public GameObject Questiontext;
  //  [SerializeField]
 //   public GameObject labelA;
  //  [SerializeField]
  //  public GameObject labelB;
  //  [SerializeField]
  //  public GameObject labelC;
    [SerializeField]
    //public GameObject labelD;
	List<Question>questions;//=SortQuiz.instance.getEasy();
    int cont=0;
   // SortQuiz sq;
   
    public void Start(){
    canvas=Player.instance.transform.GetChild(1).gameObject;
    
        //questions=SortQuiz.instance.getEasy();
        //sq.sortQuestions();
        
    /* if(difcult==0){
        questions=sq.getEasy();
     }else if(difcult==1){
        questions=sq.getNormal();
     }else{
        questions=sq.getHard();
     }*/
    }
    void Update(){
        canInteract=canvas.GetComponentInChildren<QuizManeger>().canInteract;
    }
   public override void OnFocus(){
       //Play animation
     //Debug.Log("Olhou eee");
     if(canInteract){
     transform.GetChild(0).gameObject.SetActive(true);
     // GetComponentInChildren<Animator>().Play("PlacaView");
      //GetComponentInChildren<Animator>().SetBool("Stop",false);
      GetComponentInChildren<Animator>().Rebind();}//else GetComponentInChildren<Animator>().SetBool("Stop",true);
   }
  public override void OnLoseFocus(){
      //  Debug.Log("Parou de olhar");
      //  GetComponentInChildren<Animator>().Play("PlacaFinish");
      if(canInteract)
       GetComponentInChildren<Animator>().SetBool("Stop",true);
      //  transform.GetChild(0).gameObject.SetActive(false);
  }
  
  public override void OnInteract(){
   // Debug.Log(questions[cont].getQuestion());
    //cont++;
     
       if(canInteract){
       // canvas.GetComponentInChildren<QuizManeger>().difcult=dif;
        canvas.SetActive(true);
        canvas.GetComponentInChildren<QuizManeger>().setList(dif);
        canvas.GetComponentInChildren<QuizManeger>().createQuiz();
        canInteract=false;  
        }
  }
}
