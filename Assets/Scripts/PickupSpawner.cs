using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : Spawner
{
    
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isPaused)
        {
            // Does the spawning mechanic.
            SpawnHandler();
        }
    }
    /// <summary>
    /// Does the same thing as the current spawnhandler but allows room to add things for the pickups.
    /// </summary>
    protected override void SpawnHandler()
    {
        base.SpawnHandler();
    }

    
}
