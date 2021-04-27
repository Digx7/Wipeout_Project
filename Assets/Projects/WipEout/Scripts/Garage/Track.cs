using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Track
{
    public enum DayNightCycle {morning,afternoon,evening,night};
    public enum GameMode {timeTrial, Race, Battle}
    [SerializeField] private string TrackName;
    [SerializeField] private SceneReference sceneReference;
    [SerializeField] private bool isMirrored = false;
    [SerializeField] private DayNightCycle timeOfDay;
    [SerializeField] private GameMode mode;

    public SceneReference getSceneReference(){return sceneReference;}
    public DayNightCycle getTimeOfDay(){return timeOfDay;}
    public GameMode getMode(){return mode;}
}
