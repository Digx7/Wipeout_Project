using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{

    [SerializeField] private SceneReference sceneToLoad;
    [SerializeField] private GameObject prefab;

    private void Start()
    {
        DontDestroyOnLoad(this);
        //Instantiate(prefab);
        StartCoroutine(LoadScene(sceneToLoad));
    }

    private IEnumerator LoadScene(SceneReference _sceneToLoad)
    {
      SceneReference _r = _sceneToLoad;
      // Start loading the scene
      AsyncOperation asyncLoadLevel = SceneManager.LoadSceneAsync(_r, LoadSceneMode.Single);
      // Wait until the level finish loading
      while (!asyncLoadLevel.isDone)
          yield return null;
      // Wait a frame so every Awake and Start method is called
      yield return new WaitForEndOfFrame();

      Instantiate(prefab);
    }
}
