using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testerCode : MonoBehaviour
{
    [SerializeField] private AllParts allParts;
    [SerializeField] private List<part> parts;
    [SerializeField] private List<frame_part> frames;

    public void Awake(){
      //printAllParts();
      //printAllFrames();
    }

    public void printAllParts(){
      foreach(part part in allParts.frameParts) {
        parts.Add(part);
      }
    }

    public void printAllFrames(){
      foreach(part part in parts) {
        frames.Add(part as frame_part);
      }
    }
}
