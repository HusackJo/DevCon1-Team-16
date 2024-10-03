using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    /* Class that handles the dropping of items.
     * OnDrop triggers when a mouse drag event resolves with the cursor above this object.
     * Simply accesses the DraggableItem class attached to our items, and changes the object's parent.
     */
    public void OnDrop(PointerEventData eventData)
    {
        // if the slot has no child objects (AKA it's empty)
        if (transform.childCount == 0) {
            //refrence to an item being dropped on us
            GameObject droppedItem = eventData.pointerDrag;
            //reference to that item's class
            DraggableItem draggableItem = droppedItem.GetComponent<DraggableItem>();
            //      I'm your parent now.
            draggableItem.parentAfterDrag = transform;
        }
    }

}