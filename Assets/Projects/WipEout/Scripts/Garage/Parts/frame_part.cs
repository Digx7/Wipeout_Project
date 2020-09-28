using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class frame_part
{
    /* Description --
     *  This script should hold all the varibles for a frame part
     *  This should control the general look of the ship
     */

    public string Name;
    public string type = "Frame";
    public float weight;
    public float powerNeeded;
    public bool isOwned = false;
    [Space]
    public int price;
    [Space]
    public GameObject part;
    [Space]

    public float health;


    public frame_part ()
    {

    }
}
