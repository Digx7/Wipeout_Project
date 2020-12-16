using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
  /* Description --
    This script will add a rotation to the given GameObject
  */

  public GameObject rotationObject;
  public float xAxisRotationSpeed, yAxisRotationSpeed, zAxisRotationSpeed;

  public void Awake()
  {
    if (rotationObject == null) rotationObject = gameObject;
  }
    // this function will run when the scene starts


  public void Update()
  {
    rotationObject.transform.Rotate (xAxisRotationSpeed*Time.deltaTime,yAxisRotationSpeed*Time.deltaTime,zAxisRotationSpeed*Time.deltaTime);
  }
    // this function will run once every frame
}
