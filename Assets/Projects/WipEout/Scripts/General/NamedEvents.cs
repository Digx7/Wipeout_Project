using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class NamedEvents
{
  [SerializeField] private string name;
  [SerializeField] private UnityEvent Event;

  public string getName(){
    return name;
  }

  public UnityEvent getEvent(){
    return Event;
  }

  public void invokeEvent(){
    Event.Invoke();
  }
}
