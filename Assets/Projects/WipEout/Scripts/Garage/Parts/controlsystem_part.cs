using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class controlsystem_part
{
    /* Description --
     *  This script should handel all the varibles for a control system part
     *  This handels the UI
     */

    public string Name;
    public string type = "Control System";
    public float weight;
    public float powerNeeded;
    public bool isOwned = false;
    [Space]
    public int price;
    [Space]
    public GameObject part;

    public controlsystem_part()
    {

    }
}
