using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler {

    public ImageDragging.Slot typeOfItem = ImageDragging.Slot.CorrectAnswer;

	public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        ImageDragging tile = eventData.pointerDrag.GetComponent<ImageDragging>();
        if (tile != null)
        {
            if (typeOfItem == tile.typeOfItem)
            {
                tile.parentToReturnTo = this.transform;
            }
        }
    }
}
