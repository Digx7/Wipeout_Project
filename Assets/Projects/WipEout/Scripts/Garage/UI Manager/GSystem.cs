using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSystem : MonoBehaviour
{
  [SerializeField] private int G;

  public void UpdateG (int change)
  {
    G += change;
  }

  public void setG (int input){
    G = input;
  }

  public int getG (){
    return G;
  }
}
