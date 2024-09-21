using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/*Class for our items so we can drag and drop them. Note the:
 * using UnityEngine.EventSystems;
 * line to enable easy drag and drop functionality
 * 
 */
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //variable to be assigned
    Transform parentAfterDrag;

    //
    public void OnBeginDrag(PointerEventData eventData)
    {
        //sets our placeholder to the spot it started in (on top of a UI square)
        parentAfterDrag = transform.parent;
        //these 2 lines set our parent object to our canvas, then set us to the bottom of the canvas.
        //this so so we hover above the inventory UI no matter which slot the item is placed in.
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        Debug.Log("picked up!");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = (mousePos);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        Debug.Log("dropped");
    }
}
