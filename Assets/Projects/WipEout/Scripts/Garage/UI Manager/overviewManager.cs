using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class overviewManager : MonoBehaviour
{
    /* Description ---
     *    This script should manage the overview on the left hand side
     */


    [SerializeField] private customLoadOut currentLoadOut;
    [SerializeField] private int selectedLoadOut = 0;
    [SerializeField] private AllCustomLoadouts allCustomLoadOuts;
    [Space]
    [SerializeField] private ShipStatsGenerator shipStatsGenerator;
    [SerializeField] private GeneralUIManager GeneralUIManager;
    [SerializeField] private SystemManager systemManager;

    public void Initialization ()
    {
        ReloadLoadOut();
        RefreashAllPanels();
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

        GeneralUIManager.UpdatePart (0, currentLoadOut.framePart.Name, currentLoadOut.framePart.weight.ToString(), currentLoadOut.framePart.powerNeeded.ToString());
        GeneralUIManager.UpdatePart (1, currentLoadOut.enginePart.Name, currentLoadOut.enginePart.weight.ToString(), currentLoadOut.enginePart.powerNeeded.ToString());
        GeneralUIManager.UpdatePart (2, currentLoadOut.thrusterPart.Name, currentLoadOut.thrusterPart.weight.ToString(), currentLoadOut.thrusterPart.powerNeeded.ToString());
        GeneralUIManager.UpdatePart (3, currentLoadOut.steeringFinPart.Name, currentLoadOut.steeringFinPart.weight.ToString(), currentLoadOut.steeringFinPart.powerNeeded.ToString());
        GeneralUIManager.UpdatePart (4, currentLoadOut.controlSystemPart.Name, currentLoadOut.controlSystemPart.weight.ToString(), currentLoadOut.controlSystemPart.powerNeeded.ToString());
        GeneralUIManager.UpdatePart (5, currentLoadOut.weaponSystemPart.Name, currentLoadOut.weaponSystemPart.weight.ToString(), currentLoadOut.weaponSystemPart.powerNeeded.ToString());

        GeneralUIManager.UpdateColor (0, currentLoadOut.mainColor.Name);
        GeneralUIManager.UpdateColor (1, currentLoadOut.secondaryColor.Name);
        GeneralUIManager.UpdateColor (2, currentLoadOut.trailColor.Name);

        shipStatsGenerator.GenerateStats(currentLoadOut);

        SaveLoadOut();
        systemManager.Save();
        RefreashAllStatsUI();
    }
    public void RefreashAllStatsUI ()
    {

        GeneralUIManager.UpdateStat(0, "Health", shipStatsGenerator.getHealth().ToString());
        GeneralUIManager.UpdateStat(1, "Speed", shipStatsGenerator.getSpeed().ToString());
        GeneralUIManager.UpdateStat(2, "Start Up", shipStatsGenerator.getAcceleration().ToString());
        GeneralUIManager.UpdateStat(3, "Handling", shipStatsGenerator.getTurningSpeed().ToString());
        GeneralUIManager.UpdateStat(4, "Airbrakes", shipStatsGenerator.getAirBrakes().ToString());
        GeneralUIManager.UpdateStat(5, "Weapon", shipStatsGenerator.getWeapon().ToString());
    }

    public void NewFramePart (frame_part framePart)
    {
        currentLoadOut.framePart = framePart;
        RefreashAllPanels();
    }
    public void NewEnginePart(engine_part enginePart)
    {
        currentLoadOut.enginePart = enginePart;
        RefreashAllPanels();
    }
    public void NewThrusterPart(thruster_part thrusterPart)
    {
        currentLoadOut.thrusterPart = thrusterPart;
        RefreashAllPanels();
    }
    public void NewSteeringFinPart(steeringfin_part steeringFinPart)
    {
        currentLoadOut.steeringFinPart = steeringFinPart;
        RefreashAllPanels();
    }
    public void NewControlSystemPart(controlsystem_part controlSystemPart)
    {
        currentLoadOut.controlSystemPart = controlSystemPart;
        RefreashAllPanels();
    }
    public void NewWeaponSystemPart(weaponsystem_part weaponSystemPart)
    {
        currentLoadOut.weaponSystemPart = weaponSystemPart;
        RefreashAllPanels();
    }

    public void NewMainColor(color_part color)
    {
        currentLoadOut.mainColor = color;
        RefreashAllPanels();
    }
    public void NewSecondaryColor(color_part color)
    {
        currentLoadOut.secondaryColor = color;
        RefreashAllPanels();
    }
    public void NewTrailColor(color_part color)
    {
        currentLoadOut.trailColor = color;
        RefreashAllPanels();
    }
}
