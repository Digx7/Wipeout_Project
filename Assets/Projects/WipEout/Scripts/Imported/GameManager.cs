﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("Track Settings")]
    [SerializeField] private float gravityScalar = 19.8f;
    [SerializeField] private int maxNumberofLaps = 3;
    [SerializeField] private float countDownTime = 3.0f;
    [SerializeField] private bool raceIsActive;
    [SerializeField] private bool raceIsLoading;
    [SerializeField] private UnityEvent CountDownStarted;
    [SerializeField] private UnityEvent RaceStarted;
    [Space]
    [SerializeField] private string GarageScene;

    private int numShips = 0;
    private int checkpointTotal = 0;
    private int checkpointHighest = 0;
    private List<ShipController> ships;
    private List<int> shipCheckpoints, shipPositions;
    private List<Checkpoint> checkpoints;
    private bool hasInit = false;

    void Start()
    {
        Init();
        StartUpRace();
    }

    void Init()
    {
        if (hasInit) return;
        else hasInit = true;
        ships = new List<ShipController>();
        shipCheckpoints = new List<int>();
        shipPositions = new List<int>();
        checkpoints = new List<Checkpoint>();
    }

	  void Update()
    {
        SortPositions();
	  }

    public float GetGravity()
    {
        return gravityScalar;
    }

    public int RegisterShip(ShipController ship)
    {
        Init();
        ships.Add(ship);
        shipCheckpoints.Add(0);
        shipPositions.Add(numShips);
        numShips++;
        return numShips - 1;
    }

    public int GetPosition(int shipID)
    {
        for(int i = 0; i < numShips; i++)
        {
            if(shipPositions[i] == shipID) return (numShips - i);
        }
        return -1;
    }

    void SortPositions()
    {
        shipPositions.Sort(ComparePositions);
    }

    int ComparePositions(int x, int y)
    {
        if (x == y) return 0;
        if(shipCheckpoints[x] > shipCheckpoints[y]) return 1;
        else if(shipCheckpoints[x] == shipCheckpoints[y])
        {
            float distX = 900000.0f;
            float distY = 900000.0f;
            foreach(Checkpoint cp in checkpoints)
            {
                if(cp.GetID() == (shipCheckpoints[x] + 1) % checkpointHighest)
                {
                    float dist = Vector3.Distance(ships[x].transform.position, cp.transform.position);
                    if (dist < distX) distX = dist;
                    dist = Vector3.Distance(ships[y].transform.position, cp.transform.position);
                    if (dist < distY) distY = dist;
                }
            }
            if (distX < distY) return 1;
        }
        return -1;
    }

    public int GetShipCount()
    {
        return numShips;
    }

    public void RegisterCheckpoint(int checkpointID, Checkpoint checkpoint)
    {
        Init();
        checkpointTotal++;
        if (checkpointID > checkpointHighest) checkpointHighest = checkpointID;
        checkpoints.Add(checkpoint);
    }

    public void Checkpoint(int shipID, int checkpointID)
    {
        if(shipCheckpoints[shipID] % checkpointHighest == checkpointID - 1)
        {
            shipCheckpoints[shipID]++;
        }
    }

    public int GetLaps(int shipID)
    {
        if(checkpointHighest == 0) return 0;
        return (int)Mathf.Floor(shipCheckpoints[shipID] / checkpointHighest) + 1;
    }

    // My Code ---------------

    public GameObject GetShipsLastCheckpoint(int shipID){
      return checkpoints[shipCheckpoints[shipID]].gameObject;
    }

    public void ReportLap(int shipID)
    {
        if (GetLaps(shipID) > maxNumberofLaps) ShipFinishedRace(shipID);
    }

    public void StartUpRace()
    {
      StartCoroutine(WaitForRaceToLoad());
    }

    public void ShipFinishedRace(int shipID)
    {
        ships[shipID].DisableInput();
        ships[shipID].gameObject.GetComponent<ShipHUD>().PlayEndRaceUI();

        int g = SaveSystem.LoadGData();
        g += 10;
        SaveSystem.SaveGData(g);

        StartCoroutine(ReturnToGarage(10.0f));
    }

    public IEnumerator ReturnToGarage (float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);

        loadGarageScene();

        yield return null;

        Destroy(gameObject, 0.5f);
    }

    public IEnumerator RaceCountDown (float countDownTime)
    {
      // Start count down animation
      Debug.Log("Starting Race");
      raceIsActive = false;
      CountDownStarted.Invoke();
      yield return new WaitForSeconds(countDownTime);
      RaceStarted.Invoke();
      raceIsActive = true;
      foreach(ShipController ship in ships)
      {
        ship.EnableInput();
        ship.GetComponent<ShipHUD>().startTimer();
      }
      yield return null;
    }

    private IEnumerator WaitForRaceToLoad(){
      raceIsLoading = true;

      ShipLoader[] shipLoaders;
      do {
        shipLoaders = FindObjectsOfType<ShipLoader>();
        yield return null;
      } while (shipLoaders[0] != null);

      raceIsLoading = false;

      StartCoroutine(RaceCountDown(countDownTime));

      yield return null;
    }

    public void loadGarageScene(){
      SceneManager.LoadScene(GarageScene);
    }
}
