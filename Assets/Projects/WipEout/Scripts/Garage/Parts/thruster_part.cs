using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class thruster_part : part
{
    /* Description --
     *  This script should handel all the varibles for a thruster part
     *  This controls the speed and acelleration
     */

    
    public GameObject part;
    [Space]
    public float speed;
    public float acceleration;

    public thruster_part ()
    {

    }
}
