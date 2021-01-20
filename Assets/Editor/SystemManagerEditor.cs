using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SystemManager))]
public class SystemManagerEditor : Editor
{
  public override void OnInspectorGUI()
  {
      DrawDefaultInspector();

      SystemManager myScript = (SystemManager)target;
      if(GUILayout.Button("Delete Save Data"))
      {
          myScript.Delete();
      }
  }
}
