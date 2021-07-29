using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [Header("Gizmos Tools")]
    public Vector3 boxSize = new Vector3(1, 2, 1);
    public Color gizmoColor = Color.white;
    // The prefab selected to spawn.
    protected GameObject prefabToSpawn;
    // Stores a list of prefabs to spawn.
    [Header("Spawner Mechanics:"), SerializeField,Tooltip("The list of prefabs that should spawn here.")]
    protected List<GameObject> spawnPrefabsList;
    // The spawned enity at the current time.
    protected GameObject spawnedEnity;
    // Stores the delay timer.
    [SerializeField, Tooltip("The delay between when the spawned enity was destroyed until the new is spawned.")]
    protected float spawnDelay;
    // Stores when the next spawn time is.
    protected float nextSpawnTime;
    // Stores the transform.
    protected Transform tf;

    /// <summary>
    /// Handles the spawning mechanic.
    /// </summary>
    protected virtual void SpawnHandler()
    {
        // If there's nothing spawned.
        if (spawnedEnity == null)
        {
            // If the time since the start of the game is past the set next spawn time.
            if (Time.time > nextSpawnTime)
            {
                // Pick a prefab from the list of prefabs.
                prefabToSpawn = spawnPrefabsList[Random.Range(0, spawnPrefabsList.Count)];
                // Spawn the prefab at the current location.
                spawnedEnity = Instantiate(prefabToSpawn, tf.position, tf.rotation);
                // Set the next spawntime to be the current time + delay.
                nextSpawnTime = Time.time + spawnDelay;
            }
        }
        else
        {
            // Set the next spawntime to be the current time + delay.
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // Grab the transform.
        tf = gameObject.GetComponent<Transform>();
        // Set the next spawntime to be the current time + delay.
        nextSpawnTime = Time.time + spawnDelay;
    }
    protected void OnDrawGizmos()
    {
        // Sets the gizmo's color
        Gizmos.color = gizmoColor;
        
        // Sets the box off set to fit better on the scene
        float boxOffsetY = boxSize.y / 2;
        // Draws cube at the position of the spawner
        Gizmos.DrawCube(transform.position + (boxOffsetY * Vector3.up), boxSize);
        // Draws a ray in the middle of the cube towards the direction facing.
        Gizmos.DrawRay(transform.position + (boxOffsetY * Vector3.up), transform.forward * (boxSize.z));
    }
}
