using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerDownHandler
{
    private RectTransform dragRectTransform;

    private Vector3 lastPos = Vector2.zero;

    private void Awake()
    {
        dragRectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (MouseExtension.GetUIMousePos(gameObject, eventData.position, out Vector3 newPos))
        {
            lastPos = newPos;
            transform.SetAsLastSibling();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!IsPointerOverButton(eventData))
        {
            return;
        }

        if (MouseExtension.GetUIMousePos(gameObject, eventData.position, out Vector3 newPos))
        {
            dragRectTransform.transform.position += newPos - lastPos;
        }

        lastPos = newPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsPointerOverButton(eventData))
        {
            return;
        }

        if (MouseExtension.GetUIMousePos(gameObject, eventData.position, out Vector3 newPos))
        {
            dragRectTransform.transform.position += newPos - lastPos;
        }

        lastPos = newPos;
    }

    bool IsPointerOverButton(PointerEventData eventData)
    {
        var go = eventData.pointerDrag;
        if (go == null) return false;
        return go.GetComponent<DragWindow>() != null;
    }
}
