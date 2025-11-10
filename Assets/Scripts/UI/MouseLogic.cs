using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MouseLogic : MonoBehaviour
{
    [SerializeField] private Sprite clicSprite;
    [SerializeField] private Sprite normalSprite;

    [SerializeField] private Image mouseImage;

    private void Awake()
    {
        mouseImage = GetComponent<Image>();

        Cursor.visible = false; // because I don't know how to hide it by default in the game :clown:
    }

    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            mouseImage.sprite = clicSprite;
        }
        else
        {
            mouseImage.sprite = normalSprite;
        }

        var screenPoint = Input.mousePosition;
        screenPoint.z = 10.0f; //distance of the plane from the camera
        transform.position = screenPoint;
    }
}
