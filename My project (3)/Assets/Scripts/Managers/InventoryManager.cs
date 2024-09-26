using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //Managers the inventory!
    [SerializeField]
    public ItemSlot[] InventorySlots;
    public GameObject blankItemPrefab;

    /// <summary>
    /// <para>Returns true if there is an open inventory space.</para>
    /// <para>Other objects will be able to call this method. This method takes an item as a parameter, searches for a slot, then SpawNewItem-s appropriatley.</para>
    /// NOTE: ORDER IS BASED ON ARRAY ATTACHED TO SCRIPT.
    /// </summary>
    /// <param name="item"></param>
    public bool AddItem(Item item)
    {
        //finds an empty slot
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            //ref to current slot
            ItemSlot tempSlot = InventorySlots[i];
            //ref to DraggableItem found in the slot's child object
            DraggableItem itemInSlot = tempSlot.GetComponentInChildren<DraggableItem>();
            //if there is no object in the slot, spawn the passed in item
            if(itemInSlot == null)
            {
                //debug text
                Debug.Log($"spawning item {item.name} in slot {tempSlot.name}");
                SpawnNewItem(item, tempSlot);
                return true;
            }
        }
        //and if there's no empty slots
        return false;
    }

    /// <summary>
    /// actually spawns in a draggable item. Takes item data from AddItem.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="slot"></param>
    void SpawnNewItem(Item item, ItemSlot slot)
    {
        //spawns then gets script refernce for new object
        GameObject newItem = Instantiate(blankItemPrefab, slot.transform);
        DraggableItem spawnedItemRef = newItem.GetComponent<DraggableItem>();
        //initalizes with passed in item data
        spawnedItemRef.InitalizeDraggableItem(item);
    }
}
