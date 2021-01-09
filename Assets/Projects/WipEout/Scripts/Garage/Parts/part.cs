using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class part
{
    /* Description --
     * This script should have all the elements for any given part
     */

     public string Name;
     public string type;
     public float weight;
     public float powerNeeded;
     public bool isOwned = false;
     [Space]
     public int price;

     public part()
     {

     }
}
