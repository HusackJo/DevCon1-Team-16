using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/*Class for our items so we can drag and drop them. Note the:
 * using UnityEngine.EventSystems;
 * and
 * using UnityEngine.UI;
 * lines to enable easy drag and drop functionality
 */
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //this variable is going to represent where our item locks to after the drag event
    [HideInInspector] public Transform parentAfterDrag;
    [SerializeField]
    private Image imageRef;

    //
    public void OnBeginDrag(PointerEventData eventData)
    {
        //sets our placeholder to the spot it started in (on top of a UI square)
        //we do this so the item has a parent to return to if it's not dropped anywhere meaningful.
        parentAfterDrag = transform.parent;

        //these 2 lines set our parent object to our canvas, then set us to the bottom of the canvas.
        //this so so we hover above the inventory UI no matter which slot the item is placed in.
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        //Lastly, we disable Raycast Target on our image component so our drop detection doesnt always hit the image we drag.
        //we'll re-enable this OnEndDrag so we can pick things up more than once, as well.
        imageRef.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = (mousePos);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        imageRef.raycastTarget = true;
    }
}
