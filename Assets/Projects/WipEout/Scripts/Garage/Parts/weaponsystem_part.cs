using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class weaponsystem_part
{
    /* Description --
     *  This script should handel all the varibles for a weapon system part
     *  This should handel what weapons the ship can do
     */

    public string Name;
    public string type = "Weapon System";
    public float weight;
    public float powerNeeded;
    public bool isOwned = false;
    [Space]
    public int price;
    [Space]
    public GameObject part;

    public weaponsystem_part()
    {

    }
}
