using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInventorySpawns : MonoBehaviour
{
    public InventoryManager ManagerRef;
    public Item[] itemsToSpawn;

    public void PickupItem(int arrayID)
    {
        bool result = ManagerRef.AddItem(itemsToSpawn[arrayID]);
        if (result)
        {
            Debug.Log($"added item {itemsToSpawn[arrayID].name} to inventory");
        }
        else
        {
            Debug.Log($"was unable to add {itemsToSpawn[arrayID].name} to inventory");
        }
    }
}
