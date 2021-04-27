using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader2 : MonoBehaviour
{
    [SerializeField] private List<SceneReference> scenesToLoad;

    private void Start()
    {
        SceneManager.LoadScene(scenesToLoad[0]);
    }
}
