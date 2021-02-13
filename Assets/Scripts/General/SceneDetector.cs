using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneDetector : MonoBehaviour
{
   public StringEvent NewSceneName;

   public void Awake()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }


   private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (currentName == null)
        {
            // Scene1 has been removed
            currentName = "Replaced";
        }

        Debug.Log("Scenes: " + currentName + ", " + next.name);

        NewSceneName.Invoke(next.name);
    }
}
