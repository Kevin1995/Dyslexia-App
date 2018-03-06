using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageDragging : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform parentToReturnTo = null;

    public enum Slot { CorrectAnswer, IncorrectAnswer };
    public Slot typeOfItem = Slot.CorrectAnswer;

	public void OnBeginDrag(PointerEventData data)
    {
        Debug.Log("OnBeginDrag");

        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
