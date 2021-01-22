using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string nameOfSceneToLoad;
    [SerializeField] private int indexOfSceneToLoad;
    [SerializeField] private LoadSceneMode loadMode;
    [SerializeField] private UnloadSceneOptions unloadMode;


    public void LoadScene(){
      if(nameOfSceneToLoad == "") SceneManager.LoadSceneAsync(indexOfSceneToLoad, loadMode);
      else SceneManager.LoadSceneAsync(nameOfSceneToLoad, loadMode);
    }

    public void LoadScene(InputAction.CallbackContext context)
    {
         if (context.performed)
         {
             Debug.Log("PERFORMED");
             LoadScene();
         }
    }

    public void UnloadScene(float timeDelay){
      StartCoroutine(UnloadSceneCo(timeDelay));
    }

    private IEnumerator UnloadSceneCo(float timeDelay){
      yield return new WaitForSeconds(timeDelay);

      SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(0), unloadMode);

      yield return null;
    }

    public void LoadScene(string input){
      SceneManager.LoadScene(input);
    }

    public void LoadScene(int input){
      SceneManager.LoadScene(input);
    }
}
