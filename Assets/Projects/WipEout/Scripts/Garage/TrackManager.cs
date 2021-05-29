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
      SaveSystem.SaveSelectedTrackData(tracks[index].getName());
    }

    public void UpdateSelectedTrack(Track track){
      SaveSystem.SaveSelectedTrackData(track.getName());
    }

    public Track getSelectedTrack(){
      string SelectedTrackName = SaveSystem.LoadSelectedTrackData();
      return findTrackByName(SelectedTrackName);
    }

    public string getSelectedTrackName(){
      string SelectedTrackName = SaveSystem.LoadSelectedTrackData();
      return SelectedTrackName;
    }

    private Track findTrackByName(string trackName){
      foreach(Track track in tracks){
        if(track.getName() == trackName) return track;
      }
      return null;
    }
}
