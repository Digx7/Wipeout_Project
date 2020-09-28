using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class overviewManager : MonoBehaviour
{
    public GameObject[] panels;
    public overviewPanel[] panelCode;
    public TextMeshProUGUI[] shipStatsUI;
    public customLoadOut currentLoadOut;
    public int selectedLoadOut = 0;
    public AllCustomLoadouts allCustomLoadOuts;
    [Space]
    public ShipStatsGenerator shipStatsGenerator;

    public void Initialization ()
    {
        ReloadLoadOut();
        SetUpPanelCode();
        RefreashAllPanels();
    }

    public void SetUpPanelCode ()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panelCode[i].Name = panels[i].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            panelCode[i].weight = panels[i].transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
            panelCode[i].power = panels[i].transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>();
            panelCode[i].type = panels[i].transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>();
        }
    }

    public void ReloadLoadOut ()
    {
        allCustomLoadOuts = gameObject.GetComponent<AllCustomLoadouts>();
        currentLoadOut = allCustomLoadOuts.loadouts[selectedLoadOut];
    }

    public void SaveLoadOut ()
    {
        allCustomLoadOuts = gameObject.GetComponent<AllCustomLoadouts>();
        allCustomLoadOuts.loadouts[selectedLoadOut] = currentLoadOut;
    }

    public void RefreashAllPanels ()
    {
        RefreashFramePanel();
        RefreashEnginePanel();
        RefreashSteeringFinPanel();
        RefreashThrusterPanel();
        RefreashControlSystemPanel();
        RefreashWeaponSystemPanel();
    }
    public void RefreashAllStatsUI ()
    {
        shipStatsUI[0].text = shipStatsGenerator.healthString + shipStatsGenerator.health;
        shipStatsUI[1].text = shipStatsGenerator.speedString + shipStatsGenerator.speed;
        shipStatsUI[2].text = shipStatsGenerator.accelerationString + shipStatsGenerator.acceleration;
        shipStatsUI[3].text = shipStatsGenerator.turningSpeedString + shipStatsGenerator.turningSpeed;
        shipStatsUI[4].text = shipStatsGenerator.airBrakesString + shipStatsGenerator.airBrakes;
        shipStatsUI[5].text = shipStatsGenerator.weaponString + shipStatsGenerator.weapon;

        shipStatsUI[6].text = "" + shipStatsGenerator.weight;
        shipStatsUI[7].text = "" + shipStatsGenerator.powerUsed + "/" + shipStatsGenerator.maxPower;
    }

    public void RefreashFramePanel ()
    {
        panelCode[0].Name.text = currentLoadOut.framePart.Name;
        panelCode[0].weight.text = currentLoadOut.framePart.weight.ToString();
        panelCode[0].power.text = currentLoadOut.framePart.powerNeeded.ToString();
        panelCode[0].type.text = currentLoadOut.framePart.type;

        shipStatsGenerator.GenerateStats(currentLoadOut);
        RefreashAllStatsUI();
    }
    public void RefreashEnginePanel()
    {
        panelCode[1].Name.text = currentLoadOut.enginePart.Name;
        panelCode[1].weight.text = currentLoadOut.enginePart.weight.ToString();
        panelCode[1].power.text = currentLoadOut.enginePart.powerNeeded.ToString();
        panelCode[1].type.text = currentLoadOut.enginePart.type;

        shipStatsGenerator.GenerateStats(currentLoadOut);
        RefreashAllStatsUI();
    }
    public void RefreashSteeringFinPanel()
    {
        panelCode[2].Name.text = currentLoadOut.steeringFinPart.Name;
        panelCode[2].weight.text = currentLoadOut.steeringFinPart.weight.ToString();
        panelCode[2].power.text = currentLoadOut.steeringFinPart.powerNeeded.ToString();
        panelCode[2].type.text = currentLoadOut.steeringFinPart.type;

        shipStatsGenerator.GenerateStats(currentLoadOut);
        RefreashAllStatsUI();
    }
    public void RefreashThrusterPanel()
    {
        panelCode[3].Name.text = currentLoadOut.thrusterPart.Name;
        panelCode[3].weight.text = currentLoadOut.thrusterPart.weight.ToString();
        panelCode[3].power.text = currentLoadOut.thrusterPart.powerNeeded.ToString();
        panelCode[3].type.text = currentLoadOut.thrusterPart.type;

        shipStatsGenerator.GenerateStats(currentLoadOut);
        RefreashAllStatsUI();
    }
    public void RefreashControlSystemPanel()
    {
        panelCode[4].Name.text = currentLoadOut.controlSystemPart.Name;
        panelCode[4].weight.text = currentLoadOut.controlSystemPart.weight.ToString();
        panelCode[4].power.text = currentLoadOut.controlSystemPart.powerNeeded.ToString();
        panelCode[4].type.text = currentLoadOut.controlSystemPart.type;

        shipStatsGenerator.GenerateStats(currentLoadOut);
        RefreashAllStatsUI();
    }
    public void RefreashWeaponSystemPanel()
    {
        panelCode[5].Name.text = currentLoadOut.weaponSystemPart.Name;
        panelCode[5].weight.text = currentLoadOut.weaponSystemPart.weight.ToString();
        panelCode[5].power.text = currentLoadOut.weaponSystemPart.powerNeeded.ToString();
        panelCode[5].type.text = currentLoadOut.weaponSystemPart.type;

        shipStatsGenerator.GenerateStats(currentLoadOut);
        RefreashAllStatsUI();
    }

    public void NewFramePart (frame_part framePart)
    {
        currentLoadOut.framePart = framePart;
        RefreashFramePanel();
    }
    public void NewEnginePart(engine_part enginePart)
    {
        currentLoadOut.enginePart = enginePart;
        RefreashEnginePanel();
    }
    public void NewThrusterPart(thruster_part thrusterPart)
    {
        currentLoadOut.thrusterPart = thrusterPart;
        RefreashThrusterPanel();
    }
    public void NewSteeringFinPart(steeringfin_part steeringFinPart)
    {
        currentLoadOut.steeringFinPart = steeringFinPart;
        RefreashSteeringFinPanel();
    }
    public void NewControlSystemPart(controlsystem_part controlSystemPart)
    {
        currentLoadOut.controlSystemPart = controlSystemPart;
        RefreashControlSystemPanel();
    }
    public void NewWeaponSystemPart(weaponsystem_part weaponSystemPart)
    {
        currentLoadOut.weaponSystemPart = weaponSystemPart;
        RefreashWeaponSystemPanel();
    }
}
