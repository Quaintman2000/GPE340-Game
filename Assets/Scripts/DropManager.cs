using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropItem
{
    public GameObject itemToDrop;
    public float dropWeight;
}

public class DropManager : MonoBehaviour
{
    public List<DropItem> dropTable = new List<DropItem>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject DropItem()
    {
        // Create our CDF array.
        List<float> CDFlist = new List<float>();

        // For each element in our drop table, fill in the cumulative density in the CDF arrary.
        float runningTotal = 0;
        foreach (DropItem item in dropTable)
        {
            // Update the running total by adding newest drop weight.
            runningTotal += item.dropWeight;
            // Add it to the CDF array.
            CDFlist.Add(runningTotal);
        }

        // Choose a random < our total density.
        float randomNumber = UnityEngine.Random.Range(0, runningTotal);

        // Go through our CDF array, one value at a time.
        for (int i = 0; i < CDFlist.Count; i++)
        {
            // if our random number is < the density at the point
            if (randomNumber < CDFlist[i])
            {
                // Return the item at the same (parrallel) point
                return dropTable[i].itemToDrop;
            }

        }

        // Just in case Hue breaks it.
        Debug.LogError("ERROR: Random Number exceeded CDFlist values");
        return null;
    }
}
