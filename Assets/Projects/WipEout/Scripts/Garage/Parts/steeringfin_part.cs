using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class steeringfin_part
{
    /* Description --
    *  This script should handel all the varibles for a steering fin part
    *  This handels steering
    */

    public string Name;
    public string type = "Steering Fin";
    public float weight;
    public float powerNeeded;
    public bool isOwned = false;
    [Space]
    public int price;
    [Space]
    public GameObject partL;
    public GameObject partR;
    [Space]

    public float turningSpeed;
    public float driftingSpeed;

    public steeringfin_part()
    {

    }
}
