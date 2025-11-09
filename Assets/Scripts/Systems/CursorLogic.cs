using UnityEngine;
using UnityEngine.InputSystem;

public class CursorLogic : MonoBehaviour
{
    [SerializeField] private Sprite clicSprite;
    [SerializeField] private Sprite normalSprite;

    [SerializeField] private SpriteRenderer render;

    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            render.sprite = clicSprite;
        }
        else
        {
            render.sprite = normalSprite;
        }
    }
}
