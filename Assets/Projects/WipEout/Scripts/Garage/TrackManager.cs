using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public List<Track> tracks;

    public SceneReference getScene(int index){
      if (index < tracks.Count) return tracks[index].getSceneReference();
      else return null;
    }

    public void UpdateSelectedTrack(int index){
      SaveSystem.SaveSelectedTrackData(tracks[index]);
    }

    public void UpdateSelectedTrack(Track track){
      SaveSystem.SaveSelectedTrackData(track);
    }

    public Track getSelectedTrack(){
      return SaveSystem.LoadSelectedTrackData();
    }
}
