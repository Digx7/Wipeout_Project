using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BobbingMovementScript))]
public class BobbingMovementEditor : Editor
{
    public override void OnInspectorGUI(){
      DrawDefaultInspector();

      BobbingMovementScript myScript = (BobbingMovementScript)target;
      if(GUILayout.Button("Randomize")){
        myScript.Ranomize(new Vector2(0.1f, 0.4f), new Vector2(-0.4f,0.4f), new Vector2(-0.4f,0.4f));
      }
    }
}
