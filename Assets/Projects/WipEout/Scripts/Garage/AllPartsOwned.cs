using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPartsOwned : MonoBehaviour
{
    public List<frame_part> framePartsOwned;
    public List<engine_part> enginePartsOwned;
    public List<thruster_part> thrusterPartsOwned;
    public List<steeringfin_part> steeringFinPartsOwned;
    public List<controlsystem_part> controlSystemPartsOwned;
    public List<weaponsystem_part> weaponSystemPartsOwned;

    public List<color_part> mainColorPartsOwned;
    public List<color_part> secondaryColorPartsOwned;
    public List<color_part> trailColorPartsOwned;
}
