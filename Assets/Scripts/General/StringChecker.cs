using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StringChecker : MonoBehaviour
{
  public List<NamedEvents> StringsToCheck;

  public void checkAString(string name){
    foreach(NamedEvents item in StringsToCheck){
      if(item.getName() == name) item.invokeEvent();
    }
  }
}
