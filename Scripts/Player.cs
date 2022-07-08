using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof (BoxCollider2D))]
public class Player : MonoBehaviour
{
  public static Player instance;
  public Transform point;
   //  [SerializeField]
    // private BoxCollider2D InteractionArea;
    [SerializeField]
    private float Speed=2f;
    public bool CanMove=true;
    private Vector2 moveDir;
   // [SerializeField]
    //private UI ui;
    public Rigidbody2D rb;
   // private BoxCollider2D collision;
    private Animator anim;

  public string scenePassword;
  [Header("Interaction parameters")]
    public bool canInteract=true;
    [SerializeField] private RaycastHit2D interactionRayPoint=default;
    [SerializeField] private float interactionDistance=default;
    [SerializeField] private LayerMask interactionLayer;
    private Interactable curInteractable;

    public float points=0;

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
    }
    // Start is called before the first frame update
    void Start(){
    //  collision=this.GetComponent<BoxCollider2D>();
  //  InteractionArea=GetComponentInChildren<BoxCollider2D>();
     anim=this.GetComponent<Animator>();
     
    }

    // Update is called once per frame
    void Update()
    {
      if(CanMove)
       HandleMovement();

      if(canInteract){
        HandleInteractionCheck();
        HandleInteractionInput();
      }
     //ui.setPoints(points);
     //Debug.Log(test);
    }
  void FixedUpdate(){
      //Physics Calculation
      HandleInput();
     
  }
  void HandleInput(){
      float moveX=Input.GetAxisRaw("Horizontal");
      float moveY=Input.GetAxisRaw("Vertical");
      moveDir=new Vector2(moveX,moveY).normalized;
  }
  void HandleMovement(){
      anim.SetFloat("DirH",moveDir.x);
      anim.SetFloat("DirV",moveDir.y);
      rb.velocity=new Vector2(moveDir.x*Speed,moveDir.y*Speed);
     if(moveDir!=Vector2.zero)
      point.transform.localPosition = new Vector3(moveDir.x,moveDir.y,0);
  }
  
  void HandleInteractionCheck(){
     RaycastHit2D hit= Physics2D.Raycast(point.transform.position,point.forward,1f);
     //Debug.DrawRay(point.transform.position,point.forward,Color.red);
    if(hit){
      if(hit.collider.gameObject.layer==6&&curInteractable==null/*hit.collider.gameObject.GetInstanceID()!=curInteractable.GetInstanceID()*/){
        hit.collider.TryGetComponent(out curInteractable);
        if(curInteractable){
          curInteractable.OnFocus();
    }
      }
    }else if(curInteractable){
      curInteractable.OnLoseFocus();
      curInteractable=null;
      }
  /*if raycast Hits samething
    if this obj is on the layer 6 and the curInteractable==null{
    hit.tryGetcomponet(out Interactable)
    if(curInteractable){
       curInteractable.OnFocus();
    }
  }
  else if(curInteractable){
     curInteractable.OnLoseFocus();
      curInteractable=null;
  }
    */

  
  }
  void HandleInteractionInput(){
     RaycastHit2D hit=Physics2D.Raycast(point.transform.position,point.forward,1f);
    if(Input.GetKeyDown(KeyCode.E) && curInteractable!=null && hit){
      curInteractable.OnInteract();
     // Debug.Log("FOi");
    }

  }

  /*void rayHit(){
    RaycastHit2D hit= Physics2D.Raycast(point.position,point.forward,1f);
    if(hit){
      //Debug.Log(hit.transform.name);
    }
  }*/

  public float getSpd(){
    return Speed;
  }
  public void setSpd(float x){
    Speed=x;
  }

  
  /*public void OnTriggerStay2D(Collider2D e){
     //Debug.Log("FOi");
      if(e.CompareTag("Interactable")&&Input.GetKey(KeyCode.E)){
       //Debug.Log("FOi");
      // HandleInteractionInput();
      }
  }*/
  
  
}
