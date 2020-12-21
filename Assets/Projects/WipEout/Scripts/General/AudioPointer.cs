using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPointer : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;

    public void Awake(){

      AudioManager[] components = GameObject.FindObjectsOfType<AudioManager>();
      if(components.Length > 1) Debug.Log ("There is more than one audio manager in the scene");
      else if(components.Length < 1) Debug.Log("There are no audio managers in the scene");
      else audioManager = components[0];
    }

    public void PlayAudioWithName(string name){
      if(audioManager != null) audioManager.PlayAudioWithName(name);
    }
}
