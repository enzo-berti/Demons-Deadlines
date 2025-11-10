using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IBeginDragHandler, IDragHandler ,IEndDragHandler
{
    [SerializeField] private RectTransform dragRectTransform;

    private Vector3 lastPos = Vector2.zero;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!IsPointerOverButton(eventData))
        {
            return;
        }

        lastPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsPointerOverButton(eventData))
        {
            return;
        }

        Vector3 newPos = eventData.position;
        dragRectTransform.transform.position += newPos - lastPos;

        lastPos = newPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!IsPointerOverButton(eventData))
        {
            return;
        }

    }

    bool IsPointerOverButton(PointerEventData eventData)
    {
        var go = eventData.pointerCurrentRaycast.gameObject;
        if (go == null) return false;
        return go.GetComponent<DragWindow>() != null;
    }
}
