using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question 
{
    private int ID;
    private int[] IdAnswers=new int[4];
    private string questions;
    private string[] answers=new string[4];
    // Start is called before the first frame update
    public Question(int i){
        this.ID=i;
        this.IdAnswers[0]=0;
        this.IdAnswers[1]=1;
        this.IdAnswers[2]=2;
        this.IdAnswers[3]=3;
    }
    void Start()
    {
        
    }
    public int getID(){
        return this.ID;
    }
    public void setQuestion(string s){
        this.questions=s;
    }
     public string getQuestion(){
        return this.questions;
    }
    public void setAnswers(string[] s){
        this.answers=s;
    }
    public string[] getAnswers(){
        return this.answers;
    }
    public string[] getRandomAnswers(){
        return this.RandomVet(answers);
    }
     public int[] getIDs(){
        return this.IdAnswers;
    }
    public int getIDs(int i) {
if(i<0||i>3) {
	//System.out.println("Index invalido");
	return 0;
}

	return IdAnswers[i];
	}
    public void setIDs(int[] i){
    this.IdAnswers=i;
}
    string[] RandomVet(string[] s){
        return null;
    }

   
}
