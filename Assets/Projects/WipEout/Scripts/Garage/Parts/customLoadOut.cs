using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class customLoadOut
{

    /* Description --
     *  This script should hold all the variables need for a custom load out
     */

    public frame_part framePart;
    public engine_part enginePart;
    public thruster_part thrusterPart;
    public steeringfin_part steeringFinPart;
    public controlsystem_part controlSystemPart;
    public weaponsystem_part weaponSystemPart;
    [Space]
    public color_part mainColor;
    public color_part secondaryColor;
    public color_part trailColor;

    public customLoadOut ()
    {

    }
}
