using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class engine_part : part
{
    /* Description --
     *   This script should handel all the varibles for a engine part
     *   This should control the amount of power available
     */

    
    public GameObject part;
    [Space]

    public int maxPower;

    public engine_part ()
    {

    }
}
