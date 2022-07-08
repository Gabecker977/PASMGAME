using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortQuiz : MonoBehaviour
{
	public static SortQuiz instance; 
   private static List<Question> questions =new List<Question>();

	 void Awake()
    {
        if(instance==null){
          instance=this;
        }else{
          if(instance!=this){
            Destroy(gameObject);
          }
        }
     DontDestroyOnLoad(gameObject);
	 //sortQuestions();
	     
    }
	void Start(){
		//GameObject.FindGameObjectsWithTag("Quiz");
		//Debug.Log("to aq");
		//sortQuestions();
	}
	
   public List<Question> getEasy(){
	Debug.Log("Opa");
       List<Question> temp=new List<Question>();
       for(int i=0;i<11;i++){
           temp.Add(questions[i]);
       }
       return temp;
   }
   public List<Question> getNormal(){
        List<Question> temp=new List<Question>();
       for(int i=11;i<19;i++){
           temp.Add(questions[i]);
       }
       return temp;
   }
   public List<Question> getHard(){
        List<Question> temp=new List<Question>();
       for(int i=19;i<25;i++){
           temp.Add(questions[i]);
       }
       return temp;
   }
   public List<Question> sortQuestions(){
       for(int i=0;i<25;i++){
            questions.Add(new Question(i));
            questions[i].setQuestion(this.getQuestion(i));
            questions[i].setAnswers(this.randomVet(this.getAnswers(i),questions[i].getIDs(),i));
        }
        return questions;
   }
   public string[] randomVet(string[] vet, int[] id,int j) {
	string[] temp=new string[vet.Length-1];
	int[] tempID=new int[4];
	temp=vet;
	tempID=id;
	int index;
	string tempS;
	int tempInt;
	for(int i=0;i<temp.Length;i++) {
		index=Random.Range(0,temp.Length-i);
		
		tempInt=tempID[tempID.Length-i-1];
		tempID[tempID.Length-1-i]=tempID[index];
		tempID[index]=tempInt;
		tempS=temp[temp.Length-i-1];
		temp[temp.Length-1-i]=temp[index];
		temp[index]=tempS;
	}
	questions[j].setIDs(tempID);
	return temp;
}

public List<Question> randomVet(List<Question> vet) {
	List<Question> temp=new List<Question>();
	temp=vet;
	int index;
	Question tempS;
	for(int i=0;i<temp.Count;i++) {
		index=Random.Range(0,temp.Count-i);
		tempS=temp[temp.Count-i-1];
		temp[temp.Count-1-i]=temp[index];
		temp[index]=tempS;
	}
	return temp;
}
public void RemoveQuestion(int range){
questions.RemoveRange(0,range);
}

    private string getQuestion(int id){
        string[] s={"Você chegou ao PESM e foi direto a sede administrativa, neste lugar há uma arvore que dá nome ao nosso país. "
			 +"Qual é nome dessa Arvore?"
			, "Qual é o nome do Rio que passa pelo Parque  Estadual da Serra do Mar?"
			, "Agora que você sabe o nome do rio, qual é a principal utilidade desse rio para as pessoas?"
			, "Onde o Rio Santo Antônio que passa pelo PESM Núcleo Caraguatatuba deságua?"
			, "Qual é o nome da planta que compõe o nome de nossa Cidade?, ela é muito comum no PESM"
			, "Qual é o tipo florestal que existe no PESM?"
			, "Uma fruta tipica da Mata Atlantica, que você já deve ter comido na sua merenda escolar e é um simbolo de resistencia da floresta, pois é utilizada em diversas atividades como construção civil. Qual é?"
			, "Qual é o processo realizado pelas árvores que tem como resultado a liberação oxigenio?"
			, "No PESM temos algumas trilhas que podemos fazer acompanhados por um guia, qual das trilhas abaixo pertence ao PESM?"
			, "Qual é o clima típico da Mata Atlantica do PESM-Caraguatatuba?"
			, "Na trilha do Jequitibá e em sua extensão o PESM apresenta um tipo de palmito muito comum na Mata Atlântica. Qual tipo de palmito é esse?"
			, "Em algumas arvores do PESM, encontramos uma espécie de bioindicador da qualidade do ar sendo que a coloração rosa indica que o ar esta limpo. Qual espécie faz esse papel?"
			, "Já sabemos que o palmito Jussara está correndo risco de extinção, e uma das consequencias disso é a queda da ave que vive nas copas(topos) do palmito. Qual é o nome dessa ave?"
			, "Sabemos que as Aves são dispersores de sementes e contribuem para a biodivercidade da Mata Atlântica. Esses aves são conhecidas como?"
			, "O litoral Norte de São Paulo, foi habitado por indígenas como os povos Tupinambás. Atualmente a descendencia desses povos utiliza arvores caidas para a construção de canoas. Qual é o nome desse povo?"
			, "Qual é o nome da arvore dentro do PESM que era utilizada pelos Caiçaras para fazer canoas?"
			, "Qual bairro esta localizado ao Sul da entrada principal do PESM?"
			, "Qual tipo de Unidade o PASM se enquadra?"
			, "Quis das duas trilhas abaixo são para estudo e atrativo turistico?"
			, "Você sabe o tamanho do PESM em hectares?"
			, "Qual é a porcentagem das áreas protegidas da Mata Atlântida?"
			, "O que significa Caraguáta em Tupi?"
			, "Qual das opções abaixo é uma variação típica da Mata Atântica?"
			, "O Núcleo Caraguatatuba foi incorporado ao Parque Estadual da Serra do Mar em que ano?"
			, "Em relação a esse game. Qual a categoria de educação que ele pode se enquadrar?"
			, "Qual a extensão aproximada da trilha do Jequitibá no PESM  Núcleo Caraguatatuba?"};
            return s[id];
    }
private string[] getAnswers(int id){
	id*=4;
		string[] s={"Aroeira"
			, "Guapuruvu"
			, "Pau Brasil"
			, "Carvalho"
			, "Rio Guaxinduba"
			, "Rio Juqueriquerê"
			, "Rio Santo Antônio"
			, "Rio Amazonas"
			, "Pesca"
			, "Agricultura"
			, "Consumo da população"
			, "Pecuaria"
			, "Oceano Pacífico"
			, "Oceano Glacial Ártico"
			, "Oceano Indico"
			, "Oceano Atlântico"
			, "Bromélia"
			, "Caraguatá"
			, "Camélia"
			, "Açafrão"
			, "Mata Amazônia"
			, "Mata dos Cocais"
			, "Mata Atlântica"
			, "Mata dos Pinhais"
			, "Araça"
			, "Ameixa da mata"
			, "Cambuci"
			, "Banana"
			, "Transpiração"
			, "Fotossíntese"
			, "Síntese"
			, "Reprodução"
			, "Trilha do Tamanduá"
			, "Trilha do Cambuci"
			, "Trilha do Jequitibá"
			, "Trilha do Castor"
			, "Clima Tropical de Altitude"
			, "Clima Tropical Sub-Úmido"
			, "Clima Tropical Úmido"
			, "Clima Temperado"
			, "Palmito Pupunha"
			, "Palmito Juçara"
			, "Palmito de Açaí"
			, "Palmito Guariroba"
			, "Fungos"
			, "Bactérias"
			, "Vírus"
			, "Algas"
			, "Jacuaçu"
			, "Tiê-preto"
			, "Jacutinga"
			, "Gralha-Azul"
			, "Agricultores da floresta"
			, "Pecuaristas da floresta"
			, "Mestres das florestas"
			, "Caçadores das florestas"
			, "Quilombolas"
			, "Caiçaras"
			, "Indígenas"
			, "Incas"
			, "Aroeira"
			, "Guapuruvu"
			, "Araucária"
			, "Carvalho"
			, "Jaraguazinho"
			, "Ponte Seca"
			, "Rio do Ouro"
			, "Cidade Jardim"
			, "Estação Ecológica"
			, "Parque Ecológico"
			, "Proteção Integral"
			, "Proteção Ambiental"
			, "Trilha da Canoa e Trilha do Mangue"
			, "Trilha do Tropeiro e Trilha do Poção"
			, "Trilha da Ponte Seca e Trilha da Onça"
			, "Trilha do Castor e Trilha do Lobo"
			, "35 hectares"
			, "37 hectares"
			, "38 hectares"
			, "25 hectares"
			, "80%"
			, "70%"
			, "60%"
			, "50%"
			, "Planta folhosa"
			, "Planta espinhosa"
			, "Planta lisa"
			, "Planta cheirosa"
			, "Floresta Estacional"
			, "Floresta Ombrofila"
			, "Floresta Boreal"
			, "Floresta de coníferas"
			, "1978"
			, "1977"
			, "1976"
			, "1975"
			, "Educação Emancipadora"
			, "Educação do Meio Ambiente"
			, "Educação Ambiental"
			, "Educação Florestal"
			, "500m"
			, "250m"
			, "750m"
			, "1000m"};
		
		string[] temp=new string[4];
		for(int i=0;i<4;i++) {
			temp[i]=s[id+i];
		}
			return temp;
	}
}
