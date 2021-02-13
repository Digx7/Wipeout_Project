using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grumbleAMPInterface : MonoBehaviour
{
    [SerializeField] private grumbleAMP _grumbeAMP;

    [SerializeField] private string newSongName;
    [SerializeField] private int newSongNumber;
    [SerializeField] private string newLayerName;
    [SerializeField] private int newLayerNumber;
    [SerializeField] private float fadeLength = 0.0f;
    [Space]
    [SerializeField] private float waitLength = 0.1f;

    public void callPlaySong(){
      if(_grumbeAMP.PlaySong(newSongNumber, newLayerNumber, fadeLength))
        StartCoroutine(repeatCallSong());
    }

    public void callCrossFadeToNewSong(){
      _grumbeAMP.CrossFadeToNewSong(newSongNumber, newLayerNumber, fadeLength);
    }

    public void callCrossFadeToNewSong(int songNumber){
      _grumbeAMP.CrossFadeToNewSong(songNumber, newLayerNumber, fadeLength);
    }

    public void callCrossFadeToNewLayer(){
      _grumbeAMP.CrossFadeToNewLayer(newLayerNumber);
    }

    public void setNewSongNumber(int input){
      newSongNumber = input;
    }

    public void setNewLayerNumber(int input){
      newLayerNumber = input;
    }

    IEnumerator repeatCallSong(){
      while(_grumbeAMP.PlaySong(newSongNumber, newLayerNumber, fadeLength)){
        Debug.Log("WaitingOnSong");
        yield return null;
      }

      yield return null;
    }


}
