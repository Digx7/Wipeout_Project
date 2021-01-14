using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ShipStatsGenerator : MonoBehaviour
{
    [Header ("Stats")]
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private float turningSpeed;
    [SerializeField] private float airBrakes;
    [SerializeField] private float weapon;
    [SerializeField] private float weight = 0;
    [SerializeField] private float maxPower;
    [SerializeField] private float powerUsed;
    [Space]
    /*[Header("UI String addons")]
    public string healthString = "Health : ";
    public string speedString = "Speed : ";
    public string accelerationString = "Acceleration : ";
    public string turningSpeedString = "Steering : ";
    public string airBrakesString = "Air Brakes : ";
    public string weaponString = "Weapon Power : ";*/
    [Space]
    [Header("Part Models")]
    public GameObject modelHolder;
    public float loadWaitTime = 1.0f;
    [Space]
    public GameObject frame;
    public GameObject controlSystem;
    public GameObject thruster;
    public GameObject engine;
    public GameObject finL;
    public GameObject finR;
    public float weightModifier;

    public void GenerateStats (customLoadOut loadOut)
    {
        // Stop model loading
        StopCoroutine("loadShipModel");
        DestroyAllChildren(modelHolder.transform);

        weight = 0;
        powerUsed = 0;

        // Frame
        health = loadOut.framePart.health;
        weight += loadOut.framePart.weight;
        powerUsed += loadOut.framePart.powerNeeded;
        frame = loadOut.framePart.part;

        // Engine
        maxPower = loadOut.enginePart.maxPower;
        weight += loadOut.enginePart.weight;
        powerUsed += loadOut.enginePart.powerNeeded;
        engine = loadOut.enginePart.part;

        // Thruster
        speed = loadOut.thrusterPart.speed;
        acceleration = loadOut.thrusterPart.acceleration;
        weight += loadOut.thrusterPart.weight;
        powerUsed += loadOut.thrusterPart.powerNeeded;
        thruster = loadOut.thrusterPart.part;

        // Steering Fins
        turningSpeed = loadOut.steeringFinPart.turningSpeed;
        airBrakes = loadOut.steeringFinPart.driftingSpeed;
        weight += loadOut.steeringFinPart.weight;
        powerUsed += loadOut.steeringFinPart.powerNeeded;
        finL = loadOut.steeringFinPart.partL;
        finR = loadOut.steeringFinPart.partR;

        // Control System
        weight += loadOut.controlSystemPart.weight;
        powerUsed += loadOut.controlSystemPart.powerNeeded;
        controlSystem = loadOut.controlSystemPart.part;

        // Weapon System
        weight += loadOut.weaponSystemPart.weight;
        powerUsed += loadOut.weaponSystemPart.powerNeeded;

        // Weight modifications
        health += weight / weightModifier;
        speed -= weight / weightModifier;
        acceleration -= weight / weightModifier;
        turningSpeed -= weight / weightModifier;
        airBrakes -= weight / weightModifier;

        // Start new model loading
        StartCoroutine("loadShipModel");
    }

    // get fucntions

    public float getHealth(){
      return health;
    }

    public float getSpeed(){
      return speed;
    }

    public float getAcceleration(){
      return acceleration;
    }

    public float getTurningSpeed(){
      return turningSpeed;
    }

    public float getAirBrakes(){
      return airBrakes;
    }

    public float getWeapon(){
      return weapon;
    }

    public float getMaxPower(){
      return maxPower;
    }

    public float getPowerUsed(){
      return powerUsed;
    }

    // This all should be moved to a seperate script
    public Transform FindParent(GameObject part, string Name)
    {
        foreach (Transform child in part.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject.name == Name)
            {
                return child;
            }
        }

        return null;
    }

    public void DestroyAllChildren (Transform objectWithChildren)
    {
        foreach (Transform child in objectWithChildren)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public IEnumerator loadShipModel()
    {
        Vector3 origin = new Vector3(0, 0, 0);
        Transform parent;
        parent = modelHolder.transform;

        GameObject loadedFrame = Instantiate(frame, parent.transform.position, parent.rotation, parent);

        yield return new WaitForSeconds(loadWaitTime);

        parent = FindParent(loadedFrame, "ControlSystem_Point");
        GameObject loadedControlSystem = Instantiate(controlSystem, parent.transform.position, parent.transform.rotation, parent);

        yield return new WaitForSeconds(loadWaitTime);

        parent = FindParent(loadedFrame, "Engine_Point");
        GameObject loadedEngine = Instantiate(engine, parent.transform.position, parent.rotation, parent);

        yield return new WaitForSeconds(loadWaitTime);

        parent = FindParent(loadedEngine, "Thruster_Point");
        GameObject loadedThruster = Instantiate(thruster, parent.transform.position, parent.rotation, parent);

        yield return new WaitForSeconds(loadWaitTime);

        parent = FindParent(loadedEngine, "FinL_Point");
        GameObject loadedFinL = Instantiate(finL, parent.transform.position, parent.rotation, parent);

        yield return new WaitForSeconds(loadWaitTime);

        parent = FindParent(loadedEngine, "FinR_Point");
        GameObject loadedFinR = Instantiate(finR, parent.transform.position, parent.rotation, parent);
    }
}
