using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
public virtual void Awake(){
    //Number of the interactable layer
    gameObject.layer=6;
}
  public abstract void OnFocus();
  public abstract void OnLoseFocus();
  public abstract void OnInteract();
}
