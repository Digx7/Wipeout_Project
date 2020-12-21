// Digx7
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> audioSources;
    [SerializeField] private bool setChildrenOnAwake = true;

    public void Awake(){
      if(setChildrenOnAwake) {
        clearAllSources();
        foreach (Transform child in transform){
          addAudioSource(child.gameObject);
        }
      }
    }

    public List<GameObject> getAudioSources(){
      return audioSources;
    }

    public void setAudioSources(List<GameObject> sources){
      clearAllSources();
      addAudioSources(sources);
    }

    public void addAudioSources(List<GameObject> sources){
      foreach(GameObject source in sources){
        addAudioSource(source);
      }
    }

    public void addAudioSource(GameObject source){
      audioSources.Add(source);
    }

    public void clearAllSources(){
      audioSources.Clear();
    }

    public void  PlayAudioWithName (string name){
      playAudioSource(findObjectByName(name));
    }

    private GameObject findObjectByName(string name){
      foreach (GameObject _object in audioSources){
        if(_object.name == name) return _object;
      }
      return null;
    }

    private void playAudioSource(GameObject source){
      source.GetComponent<AudioSource>().Play();
    }
}
