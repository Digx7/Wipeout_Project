using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ShipStatsGenerator : MonoBehaviour
{
    [Header ("Stats")]
    public float health;
    public float speed;
    public float acceleration;
    public float turningSpeed;
    public float airBrakes;
    public float weapon;
    public float weight = 0;
    public float maxPower;
    public float powerUsed;
    [Space]
    [Header("UI String addons")]
    public string healthString = "Health : ";
    public string speedString = "Speed : ";
    public string accelerationString = "Acceleration : ";
    public string turningSpeedString = "Steering : ";
    public string airBrakesString = "Air Brakes : ";
    public string weaponString = "Weapon Power : ";
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
