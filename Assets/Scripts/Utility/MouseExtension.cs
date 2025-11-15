using UnityEngine;

static public class MouseExtension
{
    public static bool GetUIMousePos(GameObject go, Vector3 mousePos, out Vector3 UIMousePos)
    {
        Canvas canvasGO = go.GetComponentInParent<Canvas>();
        if (canvasGO.renderMode != RenderMode.WorldSpace)
        {
            UIMousePos = mousePos;
            return true;
        }

        // Convertir la position de la souris (écran) en position monde dans le Canvas
        return RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasGO.GetComponent<RectTransform>(), mousePos, Camera.main, out UIMousePos) && RectTransformUtility.RectangleContainsScreenPoint(canvasGO.GetComponent<RectTransform>(), UIMousePos);
    }
}