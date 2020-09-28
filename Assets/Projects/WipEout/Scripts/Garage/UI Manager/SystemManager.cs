using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
  [Header("UI Manager")]
  public overviewManager overviewManager;
  public GeneralUIManager generalUIManager;
  [Header("Player Save Data")]
  public AllCustomLoadouts allCustomLoadOuts;
  [Space]
  public AllFramePartsOwned allFramePartsOwned;
  public AllEnginePartsOwned allEnginePartsOwned;
  public AllSteeringFinPartsOwned allSteeringFinPartsOwned;
  public AllThrusterPartsOwned allThrusterPartsOwned;
  public AllControlSystemPartsOwned allControlSystemPartsOwned;
  public AllWeaponSystemPartsOwned allWeaponSystemPartsOwned;
  [Space]
  public PlayerSaveData playerSaveData;
  [Space]
  [Header("Parts Data")]
  public AllParts allParts;
  [Header("G-System")]
  public GSystem gSystem;

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

  // G -------------------------------------
  public void ChangeG (int change)
  {
    gSystem.UpdateG(change);
    generalUIManager.UpdateGText(gSystem.G.ToString());
    SaveSystem.SaveGData(gSystem.G);
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

  public PlayerSaveData CreateNewSaveData ()
  {
    List<string> loadOuts = new List<string>();

    List<string> ownedFrameParts = new List<string>();
    List<string> ownedEngineParts = new List<string>();
    List<string> ownedSteeringFinParts = new List<string>();
    List<string> ownedThrusterParts = new List<string>();
    List<string> ownedControlSystemParts = new List<string>();
    List<string> ownedWeaponSystemParts = new List<string>();

    ownedFrameParts.Add(findFramePart("E-2").Name);
    ownedEngineParts.Add(findEnginePart("E-2").Name);
    ownedSteeringFinParts.Add(findSteeringFinPart("E-2").Name);
    ownedThrusterParts.Add(findThrusterPart("E-2").Name);
    ownedControlSystemParts.Add(findControlSystemPart("E-2").Name);
    ownedWeaponSystemParts.Add(findWeaponSystemPart("E-2").Name);

    loadOuts.Add(findFramePart("E-2").Name);
    loadOuts.Add(findEnginePart("E-2").Name);
    loadOuts.Add(findThrusterPart("E-2").Name);
    loadOuts.Add(findSteeringFinPart("E-2").Name);
    loadOuts.Add(findControlSystemPart("E-2").Name);
    loadOuts.Add(findWeaponSystemPart("E-2").Name);

    PlayerSaveData saveData = new PlayerSaveData(loadOuts,ownedFrameParts,ownedEngineParts,
        ownedSteeringFinParts,ownedThrusterParts,ownedControlSystemParts,
        ownedWeaponSystemParts);

    return saveData;
  }

  public PlayerSaveData compileSaveData ()
  {
    List<string> loadOuts = new List<string>();

    List<string> ownedFrameParts = new List<string>();
    List<string> ownedEngineParts = new List<string>();
    List<string> ownedSteeringFinParts = new List<string>();
    List<string> ownedThrusterParts = new List<string>();
    List<string> ownedControlSystemParts = new List<string>();
    List<string> ownedWeaponSystemParts = new List<string>();

    // copiles loadOuts lists
    foreach (customLoadOut loadOut in allCustomLoadOuts.loadouts)
    {
      loadOuts.Add(loadOut.framePart.Name);
      loadOuts.Add(loadOut.enginePart.Name);
      loadOuts.Add(loadOut.thrusterPart.Name);
      loadOuts.Add(loadOut.steeringFinPart.Name);
      loadOuts.Add(loadOut.controlSystemPart.Name);
      loadOuts.Add(loadOut.weaponSystemPart.Name);
    }

    // compiles parts lists
    foreach (frame_part part in allFramePartsOwned.partsOwned)
    {
      ownedFrameParts.Add(part.Name);
    }
    foreach (engine_part part in allEnginePartsOwned.partsOwned)
    {
      ownedEngineParts.Add(part.Name);
    }
    foreach (steeringfin_part part in allSteeringFinPartsOwned.partsOwned)
    {
      ownedSteeringFinParts.Add(part.Name);
    }
    foreach (thruster_part part in allThrusterPartsOwned.partsOwned)
    {
      ownedThrusterParts.Add(part.Name);
    }
    foreach (controlsystem_part part in allControlSystemPartsOwned.partsOwned)
    {
      ownedControlSystemParts.Add(part.Name);
    }
    foreach (weaponsystem_part part in allWeaponSystemPartsOwned.partsOwned)
    {
      ownedWeaponSystemParts.Add(part.Name);
    }

    PlayerSaveData saveData = new PlayerSaveData(loadOuts,ownedFrameParts,ownedEngineParts,
        ownedSteeringFinParts,ownedThrusterParts,ownedControlSystemParts,
        ownedWeaponSystemParts);

    return saveData;
  }

  public void proccessSaveData (PlayerSaveData data)
  {

    customLoadOut loadOut = new customLoadOut();
    loadOut.framePart = findFramePart(data.loadOuts[0]);
    loadOut.enginePart = findEnginePart(data.loadOuts[1]);
    loadOut.thrusterPart = findThrusterPart(data.loadOuts[2]);
    loadOut.steeringFinPart = findSteeringFinPart(data.loadOuts[3]);
    loadOut.controlSystemPart = findControlSystemPart(data.loadOuts[4]);
    loadOut.weaponSystemPart = findWeaponSystemPart(data.loadOuts[5]);

    allCustomLoadOuts.loadouts.Add(loadOut);

    foreach (string name in data.ownedFrameParts)
    {
      allFramePartsOwned.partsOwned.Add(findFramePart(name, true));
    }
    foreach (string name in data.ownedEngineParts)
    {
      allEnginePartsOwned.partsOwned.Add(findEnginePart(name, true));
    }
    foreach (string name in data.ownedSteeringFinParts)
    {
      allSteeringFinPartsOwned.partsOwned.Add(findSteeringFinPart(name, true));
    }
    foreach (string name in data.ownedThrusterParts)
    {
      allThrusterPartsOwned.partsOwned.Add(findThrusterPart(name, true));
    }
    foreach (string name in data.ownedControlSystemParts)
    {
      allControlSystemPartsOwned.partsOwned.Add(findControlSystemPart(name, true));
    }
    foreach (string name in data.ownedWeaponSystemParts)
    {
      allWeaponSystemPartsOwned.partsOwned.Add(findWeaponSystemPart(name, true));
    }
  }

  public frame_part findFramePart (string name, bool isOwning = false)
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
  public engine_part findEnginePart (string name, bool isOwning = false)
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
  public thruster_part findThrusterPart (string name, bool isOwning = false)
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
  public steeringfin_part findSteeringFinPart (string name, bool isOwning = false)
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
  public controlsystem_part findControlSystemPart (string name, bool isOwning = false)
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
  public weaponsystem_part findWeaponSystemPart (string name, bool isOwning = false)
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
}
