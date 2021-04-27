using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Track
{
    [SerializeField] private string trackName;
    [SerializeField] private int trackNumber;
    [SerializeField] private bool isUnlocked = false;

    //public Scene _scene;

    Track(){
      trackNumber = 1;
    }

    Track(int _number){
      trackNumber = _number;
    }

    Track(int _number, bool _isUnlocked){
      trackNumber = _number;
      isUnlocked = _isUnlocked;
    }
}
