using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testerCode : MonoBehaviour
{
    [SerializeField] private AllParts allParts;

    public void Awake(){
      //printAllParts();
    }

    public void printAllParts(){
      foreach(part part in allParts.frameParts) Debug.Log(part.Name);
    }
}
