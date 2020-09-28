using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSaveData
{
    public List<string> loadOuts;

    public List<string> ownedFrameParts;
    public List<string> ownedEngineParts;
    public List<string> ownedSteeringFinParts;
    public List<string> ownedThrusterParts;
    public List<string> ownedControlSystemParts;
    public List<string> ownedWeaponSystemParts;

    public PlayerSaveData (List<string> _loadOuts, List<string> _ownedFrameParts, List<string> _ownedEngineParts,
        List<string> _ownedSteeringFinParts, List<string> _ownedThrusterParts, List<string> _ownedControlSystemParts,
        List<string> _ownedWeaponSystemParts)
    {
        loadOuts = _loadOuts;
        ownedFrameParts = _ownedFrameParts;
        ownedEngineParts = _ownedEngineParts;
        ownedSteeringFinParts = _ownedSteeringFinParts;
        ownedThrusterParts = _ownedThrusterParts;
        ownedControlSystemParts = _ownedControlSystemParts;
        ownedWeaponSystemParts = _ownedWeaponSystemParts;
    }


}
