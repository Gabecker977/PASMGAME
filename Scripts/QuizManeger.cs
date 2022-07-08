using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManeger : MonoBehaviour
{
   private static int[]answers= {2,2,2,1,1,2,1,1,2,2, 1,0,2,0,1,1,2, 2,1,1,0,1,1,1,1};
    private int guess;
    private List<Question> questions;
    private List<Question> easyList;
    private List<Question> normalList;
    private List<Question> hardList;

    // int numOfQuestions=10;
    private GameObject[] buttons;
    
    [Header("Labels")]
    [SerializeField]
    private GameObject Questionlabel;
    [SerializeField]
    private GameObject Questiontext;
    [SerializeField]
    private GameObject labelA;
    [SerializeField]
    private GameObject labelB;
    [SerializeField]
    private GameObject labelC;
    [SerializeField]
    private GameObject labelD;
	[HideInInspector]
	public bool canInteract=true;
    public int difcult;
   int range;

    private float bonus=0;
 int curQuestion=0;
  void Awake(){
    SortQuiz.instance.sortQuestions();
    
   
 }
 public void Start(){
   
    //createQuiz();
 }
 public void setList(int d){
    if(questions==null){
        Debug.Log("Nulo");
    if(d==0){
    questions=SortQuiz.instance.getEasy();
    easyList=questions;
    range=3;
    }else if(d==1){
    questions=SortQuiz.instance.getNormal();
    normalList=questions;
    range=2;
    }else{
    questions=SortQuiz.instance.getHard();
    hardList=questions;
    range=1;
        }
    }else{
        if(d==0){
    questions=easyList;
    range=3;
    }else if(d==1){
    questions=normalList;
    }else{
    questions=hardList;
    range=1;
        }
    }
     difcult=d;
   //questions= SortQuiz.instance.sortQuestions();
    questions = SortQuiz.instance.randomVet(questions);
 }

	public void createQuiz(){
        if(questions!=null&&questions.Count!=0){
            Debug.Log("Criou");
     Player.instance.CanMove=false;
     //Debug.Log(questions[0].getQuestion());
		buttons=GameObject.FindGameObjectsWithTag("Button"); 
        Questionlabel.GetComponent<TMP_Text>().text="Questão "+(questions[curQuestion].getID()+1);
           Questiontext.GetComponent<TMP_Text>().text= questions[curQuestion].getQuestion();
           labelA.GetComponentInChildren<TMP_Text>().text=questions[curQuestion].getAnswers()[0];
           labelB.GetComponentInChildren<TMP_Text>().text=questions[curQuestion].getAnswers()[1];
           labelC.GetComponentInChildren<TMP_Text>().text=questions[curQuestion].getAnswers()[2];
           labelD.GetComponentInChildren<TMP_Text>().text=questions[curQuestion].getAnswers()[3];
           }
           else{
            this.transform.parent.gameObject.SetActive(false);
            
           }
	}
   public void nextQuestion(){
    if((curQuestion<questions.Count-1)){
       if((curQuestion>=range)){
        reset();
        //Debug.Log(questions.Count);
        //nextQuestion();
        Player.instance.CanMove=true;
        this.transform.parent.gameObject.SetActive(false);

       }else{
        Debug.Log("Abububu");
           for(int i=0;i<buttons.Length;i++){
            buttons[i].GetComponent<Button>().interactable=true;
        }
       //  Debug.Log(range+" "+curQuestion);
         labelA.GetComponent<TMP_Text>().color=new Color(255,255,255);
         labelB.GetComponent<TMP_Text>().color=new Color(255,255,255);
         labelC.GetComponent<TMP_Text>().color=new Color(255,255,255);
         labelD.GetComponent<TMP_Text>().color=new Color(255,255,255);
            
            curQuestion++;
           Questionlabel.GetComponent<TMP_Text>().text="Questão "+(questions[curQuestion].getID()+1);
           Questiontext.GetComponent<TMP_Text>().text= questions[curQuestion].getQuestion();
           labelA.GetComponentInChildren<TMP_Text>().text=questions[curQuestion].getAnswers()[0];
           labelB.GetComponentInChildren<TMP_Text>().text=questions[curQuestion].getAnswers()[1];
           labelC.GetComponentInChildren<TMP_Text>().text=questions[curQuestion].getAnswers()[2];
           labelD.GetComponentInChildren<TMP_Text>().text=questions[curQuestion].getAnswers()[3];
         // bonus=+Time.deltaTime;
       }
       }else{
        Debug.Log("Acabou as perguntas");
        canInteract=false;
        Player.instance.CanMove=true;
        this.transform.parent.gameObject.SetActive(false);
       }
       
    }
    public IEnumerator isRight(){
        for(int i=0;i<buttons.Length;i++){
            buttons[i].GetComponent<Button>().interactable=false;
        }
        this.GetComponentInChildren<Button>().interactable=false;

        if(guess==answers[questions[curQuestion].getID()]){
            
            Player.instance.points+=100;
           // Debug.Log(bonus);
            bonus=0;
            if(guess==questions[curQuestion].getIDs(0)){
                labelA.GetComponent<TMP_Text>().color=new Color(0,255,0);
            }else if(guess==questions[curQuestion].getIDs(1)){
                labelB.GetComponent<TMP_Text>().color=new Color(0,255,0);
            }else if(guess==questions[curQuestion].getIDs(2)){
                labelC.GetComponent<TMP_Text>().color=new Color(0,255,0);
            }else{
                labelD.GetComponent<TMP_Text>().color=new Color(0,255,0);
            }
        }else{  if(guess==questions[curQuestion].getIDs(0)){
                labelA.GetComponent<TMP_Text>().color=new Color(255,0,0);
            }else if(guess==questions[curQuestion].getIDs(1)){
                labelB.GetComponent<TMP_Text>().color=new Color(255,0,0);
            }else if(guess==questions[curQuestion].getIDs(2)){
                labelC.GetComponent<TMP_Text>().color=new Color(255,0,0);
            }else{
                labelD.GetComponent<TMP_Text>().color=new Color(255,0,0);
            }
           // Debug.Log(answers[questions[curQuestion].getID()]+"/"+guess);
           }
        yield return new WaitForSeconds(2);
        nextQuestion();
    }
    public void onActionA(){
        guess=questions[curQuestion].getIDs(0);
  //       Debug.Log("A");
        StartCoroutine(isRight());
    }
    public void onActionB(){
    guess=questions[curQuestion].getIDs(1);
   // Debug.Log("B");
    StartCoroutine(isRight());
    }
    public void onActionC(){
    guess=questions[curQuestion].getIDs(2);
  //  Debug.Log("C");
    StartCoroutine(isRight());
    }
    public void onActionD(){
    guess=questions[curQuestion].getIDs(3);
  //  Debug.Log("D");
    StartCoroutine(isRight());
    }  
    void reset(){
        
        
    if(difcult==0){
        easyList.RemoveRange(0,range+1);
    }else if(difcult==1){
     normalList.RemoveRange(0,range+1);
    }else{
     hardList.RemoveRange(0,range+1);
        }

        curQuestion=-1;
      //  List<Question> temp=questions;
        
      //  questions=temp;
        //easyList.RemoveRange(0,3);
        //questions=easyList;
        nextQuestion();
    }
}
