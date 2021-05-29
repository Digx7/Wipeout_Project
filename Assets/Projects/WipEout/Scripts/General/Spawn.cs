// Digx7
// This class is used by the SpawnerScript
using UnityEngine;

[System.Serializable]
public class Spawn {
    /* Description --
     *  this script will store all the needed data for a Spawn class
     */

    [Tooltip("Not used for code.  Just for your convienence.")]
    public string objectName;

    [Tooltip("What to spawn.")]
    public GameObject spawnableObject;

    public bool startOnAwake = true;

    [Tooltip("X: the minimum ammount of time between each spawn\nY: the maximum ammount of time.")]
    public Vector2 spawnRateRange = new Vector2(1.0f, 3.0f);

    [Tooltip("The maximum ammount to spawn each time called")]
    public int maxSpawn = 10;

    [Tooltip("Set to spawn indefinetly (will ignore the max spawn)")]
    public bool spawnInfinitly = false;

    public enum mode { UseCordinates, UseObject };

    [Tooltip("UseCordinates: The spawn location is set by the cordinates below\nUseObject: The spawn locations is set by the position of the GameObject below")]
    public mode spawnMode = mode.UseObject;

    [Tooltip("Only works if this sensor is in UseObject Spawn Mode")]
    public GameObject spawnLocationGameObject;

    public bool useGameObjectRotation = false;

    [Tooltip("Only works if this sensor is in UseCordinates Spawn Mode")]
    public Vector3 spawnLocation;

    [Tooltip("Sets the spawned object's parent, keep empty if you want no parent")]
    public GameObject parent;

    public bool spawnRelitiveToThisGameObject = true;

    [Tooltip("X: is the minimum\nY: the maximum")]
    public Vector2 spawnLocationXRange = new Vector2(-1.0f, 1.0f);

    [Tooltip("X: is the minimum\nY: the maximum")]
    public Vector2 spawnLocationYRange = new Vector2(-1.0f, 1.0f);

    [Tooltip("X: is the minimum\nY: the maximum")]
    public Vector2 spawnLocationZRange = new Vector2(-1.0f, 1.0f);

    public Spawn() {
    }
}
