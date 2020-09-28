﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTrail : MonoBehaviour
{
    /* Description--
     *  this script manages the trails behind each ship
     */
    /* Notes--
     *  I dont think I want to mess with this script
     */

    [SerializeField] private int numPoints = 10;
    private ShipController ship;
    private LineRenderer trail, trailCenter;
    private float prevSpeed = 0.0f;
    private float prevSideSpeed = 0.0f;
    private float prevFallSpeed = 0.0f;
    private Transform shipTransform;
    private Vector3 up, right, forward;

	void Start()
    {
        foreach (LineRenderer child in GetComponentsInChildren<LineRenderer>())
        {
            if (child.gameObject.name == "Trail")
            {
                trail = child;
            }
            else if (child.gameObject.name == "Trail center")
            {
                trailCenter = child;
            }
        }
        trail.positionCount = numPoints;
        trailCenter.positionCount = numPoints;

        //ship = GetComponentInParent<ShipController>();
        //shipTransform = ship.GetShipTransform();

        StartCoroutine("waitForShip");
    }
	
	void Update()
    {
        if (!shipTransform) return;

        float thrust = ship.GetAcceleration();
        float steer = ship.GetSteer() / 3.0f;
        float curSpeed = Mathf.Abs(ship.GetCurrentSpeed()) / ship.GetMaxSpeed();
        float curSideSpeed = ship.GetSidewaysSpeed() / ship.GetMaxSpeed();
        float speed = (Mathf.Abs(curSideSpeed) * 10.0f + curSpeed * 10.0f + curSpeed * Mathf.Abs(thrust) * 10.0f + Mathf.Abs(steer) * 5.0f) * 1.0f;
        float sideSpeed = (curSideSpeed * 5.0f - steer * 3.0f - steer * curSideSpeed * 5.0f - steer * curSpeed * 4.0f) * 1.0f;
        float fallSpeed = (ship.GetFallSpeed() / ship.GetMaxSpeed()) * 3.0f;
        fallSpeed += fallSpeed * (ship.GetPitch() / 7.0f);
        fallSpeed += (ship.GetPitch() / 7.0f) * (curSpeed * 1.5f + 0.15f);
        fallSpeed += ship.AngleChange() * 4.0f;
        if (ship.GetCurrentSpeed() < 0.0f || thrust < 0.0f)
        {
            speed *= 0.5f;
            sideSpeed *= 0.5f;
            if(thrust < 0.0f) sideSpeed *= -0.3f;
        }

        right = shipTransform.right;
        forward = shipTransform.forward;
        up = shipTransform.up;

        speed = Mathf.Lerp(prevSpeed, speed, Time.deltaTime * 7.0f);
        sideSpeed = Mathf.Lerp(prevSideSpeed, sideSpeed, Time.deltaTime * 7.0f);
        fallSpeed = Mathf.Lerp(prevFallSpeed, fallSpeed, Time.deltaTime * 7.0f);

        prevSpeed = speed;
        prevSideSpeed = sideSpeed;
        prevFallSpeed = fallSpeed;

        trail.positionCount = numPoints;
        trailCenter.positionCount = numPoints;

        Vector3 pos = trail.transform.position;
        Vector3 endPos = pos - forward * speed - right * sideSpeed - fallSpeed * up;
        Vector3 p1 = pos - forward * speed * 0.5f - right * sideSpeed * 0.25f - fallSpeed * up * 0.15f;
        Vector3 p2 = pos - forward * speed * 0.75f - right * sideSpeed * 0.75f - fallSpeed * up * 0.75f;

        trail.SetPosition(0, pos);
        trail.SetPosition(numPoints - 1, endPos);

        trailCenter.SetPosition(0, pos);
        trailCenter.SetPosition(numPoints - 1, endPos);

        for (int i = 1; i < (numPoints - 1); i++)
        {
            float t = (i) / (float)(numPoints - 1.0f);
            Vector3 p = Mathf.Pow((1.0f - t), 3.0f) * pos + 3 * Mathf.Pow((1.0f - t), 2.0f) * t * p1 + 3.0f * (1 - t) * Mathf.Pow(t, 2.0f) * p2 + Mathf.Pow(t, 3.0f) * endPos;
            trail.SetPosition(i, p);
            trailCenter.SetPosition(i, p);
        }
    }

    // My code ------

    public IEnumerator waitForShip()
    {
        while (!ship)
        {
            ship = GetComponentInParent<ShipController>();
            yield return null;
        }

        yield return  new WaitForSeconds(1.0f);

        shipTransform = ship.GetShipTransform();
    }
}
