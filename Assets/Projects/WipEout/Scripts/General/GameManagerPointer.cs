using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPointer : MonoBehaviour
{
  [SerializeField] private GameManager gameManager;

  public void Awake(){

    GameManager[] components = GameObject.FindObjectsOfType<GameManager>();
    if(components.Length > 1) Debug.Log ("There is more than one game manager in the scene");
    else if(components.Length < 1) Debug.Log("There are no game managers in the scene");
    else gameManager = components[0];
  }

  public void loadGarageScene(){
    if(gameManager != null) gameManager.loadGarageScene();
  }
}
