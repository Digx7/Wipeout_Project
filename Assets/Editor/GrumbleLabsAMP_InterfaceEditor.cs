using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(grumbleAMPInterface))]
public class GrumbleLabsAMP_InterfaceEditor : Editor
{
  public override void OnInspectorGUI()
  {
      DrawDefaultInspector();

      grumbleAMPInterface myScript = (grumbleAMPInterface)target;
      if(GUILayout.Button("CallPlaySong()"))
      {
          myScript.callPlaySong();
      }
      if(GUILayout.Button("callCrossFadeToNewSong()"))
      {
          myScript.callCrossFadeToNewSong();
      }
      if(GUILayout.Button("callCrossFadeToNewLayer()"))
      {
          myScript.callCrossFadeToNewLayer();
      }
  }
}
