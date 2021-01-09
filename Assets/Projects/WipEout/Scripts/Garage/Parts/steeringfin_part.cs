using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class steeringfin_part : part
{
    /* Description --
    *  This script should handel all the varibles for a steering fin part
    *  This handels steering
    */

    
    public GameObject partL;
    public GameObject partR;
    [Space]

    public float turningSpeed;
    public float driftingSpeed;

    public steeringfin_part()
    {

    }
}
