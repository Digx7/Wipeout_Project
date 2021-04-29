using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
  /* Description ---
   * This script should manage the high end systems
   */

  [Header("UI Manager")]
    [SerializeField] private overviewManager overviewManager;
    [SerializeField] private GeneralUIManager generalUIManager;
  [Header("Player Save Data")]
    [SerializeField] private AllCustomLoadouts allCustomLoadOuts;
    [Space]
    [SerializeField] private AllPartsOwned allPartsOwned;
    [Space]
    [SerializeField] private PlayerSaveData playerSaveData;
    [Space]
    [SerializeField] private List<string> startingFrames;
    [SerializeField] private List<string> startingEngines;
    [SerializeField] private List<string> startingThrusters;
    [SerializeField] private List<string> startingSteeringFins;
    [SerializeField] private List<string> startingControlSystems;
    [SerializeField] private List<string> startingWeaponSystems;
    [SerializeField] private List<string> startingMainColors;
    [SerializeField] private List<string> startingSecondaryColors;
    [SerializeField] private List<string> startingTrailColors;
  [Header("Parts Data")]
    [SerializeField] private AllParts allParts;
  [Header("G-System")]
    [SerializeField] private GSystem gSystem;


  // Setup -----------------------------

  public void Start ()
  {
    SaveSystem.Initialization("/WipeoutClone");

    Load();
    proccessSaveData(playerSaveData);
    overviewManager.Initialization();
    Save();

    ChangeG(SaveSystem.LoadGData());
  }

  public void OnClickQuit(){
    Application.Quit();
  }

  // G -------------------------------------
  public void ChangeG (int change)
  {
    gSystem.UpdateG(change);
    generalUIManager.UpdateGText(gSystem.getG().ToString());
    SaveSystem.SaveGData(gSystem.getG());
  }

  // Save Data Managment ---------------
  public void Save ()
  {
    playerSaveData = compileSaveData();

    SaveSystem.SavePlayerData(playerSaveData);
  }

  public void Load ()
  {
    playerSaveData = SaveSystem.LoadPlayerData();

    if (playerSaveData == null)
    {
      Debug.Log ("There is no set up save data");
      Debug.Log ("Setting up new save data");

      playerSaveData = CreateNewSaveData();
    }
  }

  public void Delete ()
  {
    SaveSystem.DeletePlayerData();
    SaveSystem.DeleteGData();
  }

  public void RefreashPartsOwnedStatus (){
    RefreashPartsOwnedStatus(playerSaveData);
  }

  public void RefreashPartsStatus (){
    RefreashPartsStatus(playerSaveData);
  }

  private PlayerSaveData CreateNewSaveData ()
  {
    List<string> loadOuts = new List<string>();

    List<string> ownedFrameParts = new List<string>();
    List<string> ownedEngineParts = new List<string>();
    List<string> ownedSteeringFinParts = new List<string>();
    List<string> ownedThrusterParts = new List<string>();
    List<string> ownedControlSystemParts = new List<string>();
    List<string> ownedWeaponSystemParts = new List<string>();

    List<string> ownedMainColors = new List<string>();
    List<string> ownedSecondaryColors = new List<string>();
    List<string> ownedTrailColors = new List<string>();

    foreach(string item in startingFrames) ownedFrameParts.Add(findFramePart(item).Name);
    foreach(string item in startingEngines) ownedEngineParts.Add(findEnginePart(item).Name);
    foreach(string item in startingThrusters) ownedThrusterParts.Add(findThrusterPart(item).Name);
    foreach(string item in startingSteeringFins) ownedSteeringFinParts.Add(findSteeringFinPart(item).Name);
    foreach(string item in startingControlSystems) ownedControlSystemParts.Add(findControlSystemPart(item).Name);
    foreach(string item in startingWeaponSystems) ownedWeaponSystemParts.Add(findWeaponSystemPart(item).Name);

    foreach(string item in startingMainColors) ownedMainColors.Add(findMainColorPart(item).Name);
    foreach(string item in startingSecondaryColors) ownedSecondaryColors.Add(findSecondaryColorPart(item).Name);
    foreach(string item in startingTrailColors) ownedTrailColors.Add(findTrailColorPart(item).Name);

    /*ownedFrameParts.Add(findFramePart("E-2").Name);
    ownedFrameParts.Add(findFramePart("Fusion").Name);
    ownedEngineParts.Add(findEnginePart("E-2").Name);
    ownedSteeringFinParts.Add(findSteeringFinPart("E-2").Name);
    ownedThrusterParts.Add(findThrusterPart("E-2").Name);
    ownedControlSystemParts.Add(findControlSystemPart("E-2").Name);
    ownedWeaponSystemParts.Add(findWeaponSystemPart("E-2").Name);*/

    loadOuts.Add(findFramePart(startingFrames[0]).Name);
    loadOuts.Add(findEnginePart(startingEngines[0]).Name);
    loadOuts.Add(findThrusterPart(startingThrusters[0]).Name);
    loadOuts.Add(findSteeringFinPart(startingSteeringFins[0]).Name);
    loadOuts.Add(findControlSystemPart(startingControlSystems[0]).Name);
    loadOuts.Add(findWeaponSystemPart(startingWeaponSystems[0]).Name);

    loadOuts.Add(findMainColorPart(startingMainColors[0]).Name);
    loadOuts.Add(findSecondaryColorPart(startingSecondaryColors[0]).Name);
    loadOuts.Add(findTrailColorPart(startingTrailColors[0]).Name);



    PlayerSaveData saveData = new PlayerSaveData(loadOuts,ownedFrameParts,ownedEngineParts,
        ownedSteeringFinParts,ownedThrusterParts,ownedControlSystemParts,
        ownedWeaponSystemParts,ownedMainColors,ownedSecondaryColors,ownedTrailColors);

    return saveData;
  }

  private PlayerSaveData compileSaveData ()
  {
    List<string> loadOuts = new List<string>();

    List<string> ownedFrameParts = new List<string>();
    List<string> ownedEngineParts = new List<string>();
    List<string> ownedSteeringFinParts = new List<string>();
    List<string> ownedThrusterParts = new List<string>();
    List<string> ownedControlSystemParts = new List<string>();
    List<string> ownedWeaponSystemParts = new List<string>();

    List<string> ownedMainColors = new List<string>();
    List<string> ownedSecondaryColors = new List<string>();
    List<string> ownedTrailColors = new List<string>();

    // copiles loadOuts lists
    foreach (customLoadOut loadOut in allCustomLoadOuts.loadouts)
    {
      loadOuts.Add(loadOut.framePart.Name);
      loadOuts.Add(loadOut.enginePart.Name);
      loadOuts.Add(loadOut.thrusterPart.Name);
      loadOuts.Add(loadOut.steeringFinPart.Name);
      loadOuts.Add(loadOut.controlSystemPart.Name);
      loadOuts.Add(loadOut.weaponSystemPart.Name);

      loadOuts.Add(loadOut.mainColor.Name);
      loadOuts.Add(loadOut.secondaryColor.Name);
      loadOuts.Add(loadOut.trailColor.Name);
    }

    // compiles parts lists
    foreach (frame_part part in allPartsOwned.framePartsOwned)
    {
      ownedFrameParts.Add(part.Name);
    }
    foreach (engine_part part in allPartsOwned.enginePartsOwned)
    {
      ownedEngineParts.Add(part.Name);
    }
    foreach (steeringfin_part part in allPartsOwned.steeringFinPartsOwned)
    {
      ownedSteeringFinParts.Add(part.Name);
    }
    foreach (thruster_part part in allPartsOwned.thrusterPartsOwned)
    {
      ownedThrusterParts.Add(part.Name);
    }
    foreach (controlsystem_part part in allPartsOwned.controlSystemPartsOwned)
    {
      ownedControlSystemParts.Add(part.Name);
    }
    foreach (weaponsystem_part part in allPartsOwned.weaponSystemPartsOwned)
    {
      ownedWeaponSystemParts.Add(part.Name);
    }

    foreach (color_part part in allPartsOwned.mainColorPartsOwned)
    {
      ownedMainColors.Add(part.Name);
    }
    foreach (color_part part in allPartsOwned.secondaryColorPartsOwned)
    {
      ownedSecondaryColors.Add(part.Name);
    }
    foreach (color_part part in allPartsOwned.trailColorPartsOwned)
    {
      ownedTrailColors.Add(part.Name);
    }

    PlayerSaveData saveData = new PlayerSaveData(loadOuts,ownedFrameParts,ownedEngineParts,
        ownedSteeringFinParts,ownedThrusterParts,ownedControlSystemParts,
        ownedWeaponSystemParts,ownedMainColors,ownedSecondaryColors,ownedTrailColors);

    return saveData;
  }

  private void proccessSaveData (PlayerSaveData data)
  {

    customLoadOut loadOut = new customLoadOut();
    loadOut.framePart = findFramePart(data.loadOuts[0]);
    loadOut.enginePart = findEnginePart(data.loadOuts[1]);
    loadOut.thrusterPart = findThrusterPart(data.loadOuts[2]);
    loadOut.steeringFinPart = findSteeringFinPart(data.loadOuts[3]);
    loadOut.controlSystemPart = findControlSystemPart(data.loadOuts[4]);
    loadOut.weaponSystemPart = findWeaponSystemPart(data.loadOuts[5]);

    loadOut.mainColor = findMainColorPart(data.loadOuts[6]);
    loadOut.secondaryColor = findSecondaryColorPart(data.loadOuts[7]);
    loadOut.trailColor = findTrailColorPart(data.loadOuts[8]);

    allCustomLoadOuts.loadouts.Add(loadOut);

    RefreashPartsOwnedStatus(data);
  }

  private void RefreashPartsOwnedStatus(PlayerSaveData data){
    foreach (string name in data.ownedFrameParts)
    {
      allPartsOwned.framePartsOwned.Add(findFramePart(name, true));
    }
    foreach (string name in data.ownedEngineParts)
    {
      allPartsOwned.enginePartsOwned.Add(findEnginePart(name, true));
    }
    foreach (string name in data.ownedSteeringFinParts)
    {
      allPartsOwned.steeringFinPartsOwned.Add(findSteeringFinPart(name, true));
    }
    foreach (string name in data.ownedThrusterParts)
    {
      allPartsOwned.thrusterPartsOwned.Add(findThrusterPart(name, true));
    }
    foreach (string name in data.ownedControlSystemParts)
    {
      allPartsOwned.controlSystemPartsOwned.Add(findControlSystemPart(name, true));
    }
    foreach (string name in data.ownedWeaponSystemParts)
    {
      allPartsOwned.weaponSystemPartsOwned.Add(findWeaponSystemPart(name, true));
    }

    foreach (string name in data.ownedMainColors)
    {
      allPartsOwned.mainColorPartsOwned.Add(findMainColorPart(name, true));
    }
    foreach (string name in data.ownedSecondaryColors)
    {
      allPartsOwned.secondaryColorPartsOwned.Add(findSecondaryColorPart(name, true));
    }
    foreach (string name in data.ownedTrailColors)
    {
      allPartsOwned.trailColorPartsOwned.Add(findTrailColorPart(name, true));
    }
  }

  private void RefreashPartsStatus(PlayerSaveData data){
    foreach (string name in data.ownedFrameParts)
    {
      findFramePart(name, true);
    }
    foreach (string name in data.ownedEngineParts)
    {
      findEnginePart(name, true);
    }
    foreach (string name in data.ownedThrusterParts)
    {
      findThrusterPart(name, true);
    }
    foreach (string name in data.ownedSteeringFinParts)
    {
      findSteeringFinPart(name, true);
    }
    foreach (string name in data.ownedControlSystemParts)
    {
      findControlSystemPart(name, true);
    }
    foreach (string name in data.ownedWeaponSystemParts)
    {
      findWeaponSystemPart(name, true);
    }

    foreach (string name in data.ownedMainColors)
    {
      findMainColorPart(name, true);
    }
    foreach (string name in data.ownedSecondaryColors)
    {
      findSecondaryColorPart(name, true);
    }
    foreach (string name in data.ownedTrailColors)
    {
      findTrailColorPart(name, true);
    }
  }

  private frame_part findFramePart (string name, bool isOwning = false)
  {
    foreach (frame_part part in allParts.frameParts)
    {
      if (part.Name == name)
      {
        if (isOwning) part.isOwned = true;
        return part;
      }
    }

    Debug.LogError("No part with the name " + name + " was found");
    return null;
  }
  private engine_part findEnginePart (string name, bool isOwning = false)
  {
    foreach (engine_part part in allParts.engineParts)
    {
      if (part.Name == name)
      {
        if (isOwning) part.isOwned = true;
        return part;
      }
    }

    Debug.LogError("No part with the name " + name + " was found");
    return null;
  }
  private thruster_part findThrusterPart (string name, bool isOwning = false)
  {
    foreach (thruster_part part in allParts.thrusterParts)
    {
      if (part.Name == name)
      {
        if (isOwning) part.isOwned = true;
        return part;
      }
    }

    Debug.LogError("No part with the name " + name + " was found");
    return null;
  }
  private steeringfin_part findSteeringFinPart (string name, bool isOwning = false)
  {
    foreach (steeringfin_part part in allParts.steeringFinParts)
    {
      if (part.Name == name)
      {
        if (isOwning) part.isOwned = true;
        return part;
      }
    }

    Debug.LogError("No part with the name " + name + " was found");
    return null;
  }
  private controlsystem_part findControlSystemPart (string name, bool isOwning = false)
  {
    foreach (controlsystem_part part in allParts.controlSystemParts)
    {
      if (part.Name == name)
      {
        if (isOwning) part.isOwned = true;
        return part;
      }
    }

    Debug.LogError("No part with the name " + name + " was found");
    return null;
  }
  private weaponsystem_part findWeaponSystemPart (string name, bool isOwning = false)
  {
    foreach (weaponsystem_part part in allParts.weaponSystemParts)
    {
      if (part.Name == name)
      {
        if (isOwning) part.isOwned = true;
        return part;
      }
    }

    Debug.LogError("No part with the name " + name + " was found");
    return null;
  }

  private color_part findMainColorPart (string name, bool isOwning = false)
  {
    foreach (color_part part in allParts.mainColorParts)
    {
      if (part.Name == name)
      {
        if (isOwning) part.isOwned = true;
        return part;
      }
    }

    Debug.LogError("No part with the name " + name + " was found");
    return null;
  }
  private color_part findSecondaryColorPart (string name, bool isOwning = false)
  {
    foreach (color_part part in allParts.secondaryColorParts)
    {
      if (part.Name == name)
      {
        if (isOwning) part.isOwned = true;
        return part;
      }
    }

    Debug.LogError("No part with the name " + name + " was found");
    return null;
  }
  private color_part findTrailColorPart (string name, bool isOwning = false)
  {
    foreach (color_part part in allParts.trailColorParts)
    {
      if (part.Name == name)
      {
        if (isOwning) part.isOwned = true;
        return part;
      }
    }

    Debug.LogError("No part with the name " + name + " was found");
    return null;
  }

}
