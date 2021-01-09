using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GeneralUIManager))]
public class GeneralUIEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GeneralUIManager myScript = (GeneralUIManager)target;
        if(GUILayout.Button("Set Colors"))
        {
            myScript.UpdateColors();
        }
        if(GUILayout.Button("Find All Images"))
        {
            myScript.FindAllImages();
        }
    }
}
