using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class thruster_part
{
    /* Description --
     *  This script should handel all the varibles for a thruster part
     *  This controls the speed and acelleration
     */

    public string Name;
    public string type = "Thruster";
    public float weight;
    public float powerNeeded;
    public bool isOwned = false;
    [Space]
    public int price;
    [Space]
    public GameObject part;
    [Space]
    public float speed;
    public float acceleration;

    public thruster_part ()
    {

    }
}
