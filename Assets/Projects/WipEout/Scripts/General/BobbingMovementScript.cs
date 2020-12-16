using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbingMovementScript : MonoBehaviour
{
  /* Description --
    This script will add a up and down movent to the GameObject
  */

  public GameObject movenmentObject;
  public float speed;
  public float maxHight, minHight;
  private Vector3 startingPos;
  private bool movingUp = true;

  public void Awake()
  {
    if(movenmentObject == null) movenmentObject = gameObject;

    startingPos = movenmentObject.transform.position;
    maxHight += startingPos.y;
    minHight += startingPos.y;
  }

  public void Update()
  {
    if (movenmentObject.transform.position.y >= maxHight)
    {
      //move down
      movingUp = false;
    }
    else if (movenmentObject.transform.position.y <= minHight)
    {
      //move up
      movingUp = true;
    }

    if (movingUp)
    {
      movenmentObject.transform.position += Vector3.up * speed * Time.deltaTime;
    }
    else
    {
      movenmentObject.transform.position -= Vector3.up * speed * Time.deltaTime;
    }
  }
}
