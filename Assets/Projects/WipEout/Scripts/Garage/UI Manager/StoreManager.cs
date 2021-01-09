using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreManager : MonoBehaviour
{
    /* Description ---
     * This script should manage the store
     */

    [Header ("UI")]
      public AllParts allParts;
      public SystemManager systemManager;
      public GSystem gSystem;
      public GeneralUIManager generalUIManager;
    [Space]
    [Header("GameObjects")]
      public GameObject MainPanel;
      public GameObject partsPrefab;
      public GameObject partsParent;
    [Space]
    [Header ("Parts Owned")]
      public AllFramePartsOwned allFramePartsOwned;
      public AllEnginePartsOwned allEnginePartsOwned;
      public AllThrusterPartsOwned allThrusterPartsOwned;
      public AllSteeringFinPartsOwned allSteeringFinPartsOwned;
      public AllControlSystemPartsOwned allControlSystemPartsOwned;
      public AllWeaponSystemPartsOwned allWeaponSystemPartsOwned;
    [Space]
    [Header ("Prefab Positions")]
      public Vector3 partPosStartingPoint;
      public Vector3 partPosOffset;

    public void enableMainPanel ()
    {
        MainPanel.SetActive(true);
    }
    public void disableMainPanel ()
    {
        MainPanel.SetActive(false);
    }
    public void resetPanel ()
    {
        foreach (Transform child in partsParent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        disableMainPanel();
    }

    public void loadAllFrameParts ()
    {
      resetPanel();
      enableMainPanel();
      int p = 0;
      for (int i = 0; i < allParts.frameParts.Count; i++) // should not load any owned parts
      {
          if (allParts.frameParts[i].isOwned == true) continue;

          p++;
          int _p = p-1;
          Vector3 Pos = partPosStartingPoint;
          Pos.x += partPosOffset.x * _p;
          GameObject g = Instantiate( partsPrefab, Pos, Quaternion.identity);

          g.transform.SetParent(partsParent.transform, false);

          g.GetComponent<partsPanel>().framePart = allParts.frameParts[i];
          g.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = allParts.frameParts[i].weight.ToString();
          g.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = allParts.frameParts[i].powerNeeded.ToString();
          g.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = allParts.frameParts[i].price.ToString();

          int x = i;
          g.GetComponent<partsPanel>().button = g.transform.GetChild(5).gameObject.GetComponent<Button>();
          g.GetComponent<partsPanel>().button.onClick.AddListener(() => buyPart (gSystem.getG(), x, frame: g.GetComponent<partsPanel>().framePart));
          g.GetComponent<partsPanel>().button.onClick.AddListener(() => resetPanel());
      }
    }
    public void loadAllEngineParts ()
    {
      resetPanel();
      enableMainPanel();
      int p = 0;
      for (int i = 0; i < allParts.engineParts.Count; i++) // should not load any owned parts
      {
          if (allParts.engineParts[i].isOwned == true) continue;

          p++;
          int _p = p-1;
          Vector3 Pos = partPosStartingPoint;
          Pos.x += partPosOffset.x * _p;
          GameObject g = Instantiate( partsPrefab, Pos, Quaternion.identity);

          g.transform.SetParent(partsParent.transform, false);

          g.GetComponent<partsPanel>().enginePart = allParts.engineParts[i];
          g.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = allParts.engineParts[i].weight.ToString();
          g.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = allParts.engineParts[i].powerNeeded.ToString();
          g.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = allParts.engineParts[i].price.ToString();

          int x = i;
          g.GetComponent<partsPanel>().button = g.transform.GetChild(5).gameObject.GetComponent<Button>();
          g.GetComponent<partsPanel>().button.onClick.AddListener(() => buyPart (gSystem.getG(), x, engine: g.GetComponent<partsPanel>().enginePart));
          g.GetComponent<partsPanel>().button.onClick.AddListener(() => resetPanel());
      }
    }
    public void loadAllSteeringFinParts ()
    {
      resetPanel();
      enableMainPanel();
      int p = 0;
      for (int i = 0; i < allParts.steeringFinParts.Count; i++) // should not load any owned parts
      {
          if (allParts.steeringFinParts[i].isOwned == true) continue;

          p++;
          int _p = p-1;
          Vector3 Pos = partPosStartingPoint;
          Pos.x += partPosOffset.x * _p;
          GameObject g = Instantiate( partsPrefab, Pos, Quaternion.identity);

          g.transform.SetParent(partsParent.transform, false);

          g.GetComponent<partsPanel>().steeringFinPart = allParts.steeringFinParts[i];
          g.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = allParts.steeringFinParts[i].weight.ToString();
          g.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = allParts.steeringFinParts[i].powerNeeded.ToString();
          g.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = allParts.steeringFinParts[i].price.ToString();

          int x = i;
          g.GetComponent<partsPanel>().button = g.transform.GetChild(5).gameObject.GetComponent<Button>();
          g.GetComponent<partsPanel>().button.onClick.AddListener(() => buyPart (gSystem.getG(), x, steeringfin: g.GetComponent<partsPanel>().steeringFinPart));
          g.GetComponent<partsPanel>().button.onClick.AddListener(() => resetPanel());
      }
    }
    public void loadAllThrusterParts ()
    {
      resetPanel();
      enableMainPanel();
      int p = 0;
      for (int i = 0; i < allParts.thrusterParts.Count; i++) // should not load any owned parts
      {
          if (allParts.thrusterParts[i].isOwned == true) continue;

          p++;
          int _p = p-1;
          Vector3 Pos = partPosStartingPoint;
          Pos.x += partPosOffset.x * _p;
          GameObject g = Instantiate( partsPrefab, Pos, Quaternion.identity);

          g.transform.SetParent(partsParent.transform, false);

          g.GetComponent<partsPanel>().thrusterPart = allParts.thrusterParts[i];
          g.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = allParts.thrusterParts[i].weight.ToString();
          g.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = allParts.thrusterParts[i].powerNeeded.ToString();
          g.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = allParts.thrusterParts[i].price.ToString();

          int x = i;
          g.GetComponent<partsPanel>().button = g.transform.GetChild(5).gameObject.GetComponent<Button>();
          g.GetComponent<partsPanel>().button.onClick.AddListener(() => buyPart (gSystem.getG(), x, thruster: g.GetComponent<partsPanel>().thrusterPart));
          g.GetComponent<partsPanel>().button.onClick.AddListener(() => resetPanel());
      }
    }
    public void loadAllControlSystemParts ()
    {
      resetPanel();
      enableMainPanel();
      int p = 0;
      for (int i = 0; i < allParts.controlSystemParts.Count; i++) // should not load any owned parts
      {
          if (allParts.controlSystemParts[i].isOwned == true) continue;

          p++;
          int _p = p-1;
          Vector3 Pos = partPosStartingPoint;
          Pos.x += partPosOffset.x * _p;
          GameObject g = Instantiate( partsPrefab, Pos, Quaternion.identity);

          g.transform.SetParent(partsParent.transform, false);

          g.GetComponent<partsPanel>().controlSystemPart = allParts.controlSystemParts[i];
          g.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = allParts.controlSystemParts[i].weight.ToString();
          g.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = allParts.controlSystemParts[i].powerNeeded.ToString();
          g.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = allParts.controlSystemParts[i].price.ToString();

          int x = i;
          g.GetComponent<partsPanel>().button = g.transform.GetChild(5).gameObject.GetComponent<Button>();
          g.GetComponent<partsPanel>().button.onClick.AddListener(() => buyPart (gSystem.getG(), x, controlsystem: g.GetComponent<partsPanel>().controlSystemPart));
          g.GetComponent<partsPanel>().button.onClick.AddListener(() => resetPanel());
      }
    }
    public void loadAllWeaponSystemParts ()
    {
      resetPanel();
      enableMainPanel();
      int p = 0;
      for (int i = 0; i < allParts.weaponSystemParts.Count; i++) // should not load any owned parts
      {
          if (allParts.weaponSystemParts[i].isOwned == true) continue;

          p++;
          int _p = p-1;
          Vector3 Pos = partPosStartingPoint;
          Pos.x += partPosOffset.x * _p;
          GameObject g = Instantiate( partsPrefab, Pos, Quaternion.identity);

          g.transform.SetParent(partsParent.transform, false);

          g.GetComponent<partsPanel>().weaponSystemPart = allParts.weaponSystemParts[i];
          g.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = allParts.weaponSystemParts[i].weight.ToString();
          g.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = allParts.weaponSystemParts[i].powerNeeded.ToString();
          g.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = allParts.weaponSystemParts[i].price.ToString();

          int x = i;
          g.GetComponent<partsPanel>().button = g.transform.GetChild(5).gameObject.GetComponent<Button>();
          g.GetComponent<partsPanel>().button.onClick.AddListener(() => buyPart (gSystem.getG(), x, weaponsystem: g.GetComponent<partsPanel>().weaponSystemPart));
          g.GetComponent<partsPanel>().button.onClick.AddListener(() => resetPanel());
      }
    }

    public void buyPart (int g, int i,  frame_part frame = null, engine_part engine = null, steeringfin_part steeringfin = null,
     thruster_part thruster = null, controlsystem_part controlsystem = null, weaponsystem_part weaponsystem = null)
    {
      if (frame != null && g >= frame.price)
      {
        Debug.Log ("You bought the part");
        resetPanel();

        // Need to subtract funds and add to owned lists

        gSystem.UpdateG(-frame.price);
        allParts.frameParts[i].isOwned = true;
        allFramePartsOwned.partsOwned.Add(frame);
        generalUIManager.UpdateGText(gSystem.getG().ToString());


        systemManager.Save();
        SaveSystem.SaveGData(gSystem.getG());
      }
      else if (engine != null && g >= engine.price)
      {
        Debug.Log ("You bought the part");
        resetPanel();

        // Need to subtract funds and add to owned lists

        gSystem.UpdateG(-engine.price);
        allParts.engineParts[i].isOwned = true;
        allEnginePartsOwned.partsOwned.Add(engine);
        generalUIManager.UpdateGText(gSystem.getG().ToString());


        systemManager.Save();
        SaveSystem.SaveGData(gSystem.getG());
      }
      else if (steeringfin != null && g >= steeringfin.price)
      {
        Debug.Log ("You bought the part");
        resetPanel();

        // Need to subtract funds and add to owned lists

        gSystem.UpdateG(-steeringfin.price);
        allParts.steeringFinParts[i].isOwned = true;
        allSteeringFinPartsOwned.partsOwned.Add(steeringfin);
        generalUIManager.UpdateGText(gSystem.getG().ToString());


        systemManager.Save();
        SaveSystem.SaveGData(gSystem.getG());
      }
      else if (thruster != null && g >= thruster.price)
      {
        Debug.Log ("You bought the part");
        resetPanel();

        // Need to subtract funds and add to owned lists

        gSystem.UpdateG(-thruster.price);
        allParts.thrusterParts[i].isOwned = true;
        allThrusterPartsOwned.partsOwned.Add(thruster);
        generalUIManager.UpdateGText(gSystem.getG().ToString());


        systemManager.Save();
        SaveSystem.SaveGData(gSystem.getG());
      }
      else if (controlsystem != null && g >= controlsystem.price)
      {
        Debug.Log ("You bought the part");
        resetPanel();

        // Need to subtract funds and add to owned lists

        gSystem.UpdateG(-controlsystem.price);
        allParts.controlSystemParts[i].isOwned = true;
        allControlSystemPartsOwned.partsOwned.Add(controlsystem);
        generalUIManager.UpdateGText(gSystem.getG().ToString());


        systemManager.Save();
        SaveSystem.SaveGData(gSystem.getG());
      }
      else if (weaponsystem != null && g >= weaponsystem.price)
      {
        Debug.Log ("You bought the part");
        resetPanel();

        // Need to subtract funds and add to owned lists

        gSystem.UpdateG(-weaponsystem.price);
        allParts.weaponSystemParts[i].isOwned = true;
        allWeaponSystemPartsOwned.partsOwned.Add(weaponsystem);
        generalUIManager.UpdateGText(gSystem.getG().ToString());


        systemManager.Save();
        SaveSystem.SaveGData(gSystem.getG());
      }
    }
}
