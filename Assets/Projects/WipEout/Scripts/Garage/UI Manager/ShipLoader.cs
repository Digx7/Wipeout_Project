using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipLoader : MonoBehaviour
{
    public ShipStats stats;
    public ShipStatsGenerator shipStatsGenerator;
    [SerializeField] private int trackNumber = 1;
    [Space]
    public GameObject ShipBasePreFab;
    public GameObject spawnedShip;
    public Vector3 ShipSpawnLocation;
    public Quaternion ShipSpawnRotation;
    public ShipSettings settings;
    [Space]
    public GameObject ShipPrefabBase;
    public GameObject frame;
    public GameObject controlSystem;
    public GameObject thruster;
    public GameObject engine;
    public GameObject finL;
    public GameObject finR;
    [Space]
    public Color mainColor;
    public Color secondaryColor;
    public Color trailColor;
    [Space]
    public Canvas HUD;
    public Canvas spawnedHUD;
    [Space]
    public float loadWaitTime = 5.0f;
    [Space]
    private GameObject loadedPreFabBase;

    private IEnumerator setUpPrefab;

    public void Awake ()
    {
        DontDestroyOnLoad(this);
    }

    public void LoadShip ()
    {
      int sceneIndexToLoad = SceneManager.GetActiveScene().buildIndex + trackNumber;

        GetStats();
        newScene(sceneIndexToLoad);
        //StartCoroutine(waitForSceneLoad(SceneManager.GetActiveScene().buildIndex + trackNumber));
    }

    public void GetStats ()
    {
        stats.health = shipStatsGenerator.health;
        stats.speed = shipStatsGenerator.speed;
        stats.acceleration = shipStatsGenerator.acceleration;
        stats.turningSpeed = shipStatsGenerator.turningSpeed;
        stats.airBrakes = shipStatsGenerator.airBrakes;
        stats.weapon = shipStatsGenerator.weapon;

        // Gets ship model pieces
        frame = shipStatsGenerator.frame;
        controlSystem = shipStatsGenerator.controlSystem;
        thruster = shipStatsGenerator.thruster;
        engine = shipStatsGenerator.engine;
        finL = shipStatsGenerator.finL;
        finR = shipStatsGenerator.finR;
    }

    public void setStats ()
    {
        settings = spawnedShip.GetComponent<ShipController>().handling;

        settings.speed = stats.speed;
        settings.acceleration = stats.acceleration;
        settings.airBrake = stats.airBrakes/10;
        settings.steerSpeed = stats.turningSpeed/10;

        UnityEngine.Debug.Log("Stats should be set");
    }

    public void newScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);

        UnityEngine.Debug.Log("Loading next scene");

        if (SceneManager.GetActiveScene().buildIndex != sceneNumber)
        {
            StartCoroutine("waitForSceneLoad", sceneNumber);
        }
    }

    IEnumerator waitForSceneLoad(int sceneNumber)
    {
        while (SceneManager.GetActiveScene().buildIndex != sceneNumber)
        {
            yield return null;
        }

        // Do anything after proper scene has been loaded
         if (SceneManager.GetActiveScene().buildIndex == sceneNumber)
        {
           StartCoroutine("loadShipPrefab");

            UnityEngine.Debug.Log(SceneManager.GetActiveScene().buildIndex);
            //GameObject spawner = GameObject.FindWithTag("scene" + sceneNumber);
            //spawner.GetComponent<spawnPlayer>().spawn(team);
        }
        //currentScene = sceneNumber;
    }

    public void SpawnShip ()
    {
        spawnedShip = Instantiate(ShipBasePreFab, ShipSpawnLocation, ShipSpawnRotation);
        spawnedShip.GetComponent<ShipController>().shipPrefab = loadedPreFabBase;

        spawnedShip.GetComponent<ShipHUD>().HUD = spawnedHUD;
    }

    public Transform FindParent (GameObject part, string Name)
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

    public void LoadShipPreFab ()
    {
        StartCoroutine("loadShipPrefab");
    }

    public void LoadShipBase ()
    {
        StartCoroutine("setUpShip");
    }

    /*public void SetColor (GameObject object, Color main, Color secondary)
    {
      // find children with renders
      // find materials with correct name
      // set colors of found materials to correct color
    }*/

    public IEnumerator setUpShip ()
    {
        yield return new WaitForSeconds(loadWaitTime);

        SpawnShip();
        yield return null;
        setStats();
        yield return null;
        Destroy(gameObject, 0.5f);

    }

    public IEnumerator loadShipPrefab ()
    {
        yield return new WaitForSeconds(loadWaitTime);

        Vector3 origin = new Vector3(0, 0, 0);
        Transform parent;

        loadedPreFabBase = Instantiate(ShipPrefabBase, origin, Quaternion.identity);

        yield return new WaitForSeconds(loadWaitTime);

        parent = FindParent(loadedPreFabBase, "ShipModel");
        GameObject loadedFrame = Instantiate(frame, parent.transform.position, parent.rotation, parent);

        yield return new WaitForSeconds(loadWaitTime);

        parent = FindParent(loadedFrame, "ControlSystem_Point");
        GameObject loadedControlSystem = Instantiate(controlSystem, parent.transform.position, parent.rotation, parent);

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

        yield return new WaitForSeconds(loadWaitTime);

        spawnedHUD = Instantiate(HUD, origin, Quaternion.identity);

        LoadShipBase();
    }
}
