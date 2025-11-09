using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class screenGameplay : MonoBehaviour
{
    [SerializeField] CinemachineCamera screenCamera;
    [SerializeField] CinemachineCamera deskCamera;
    [SerializeField] Phone phone;
    [SerializeField] PlayerMovement playerMovement;

    public bool onScreen = false;

    [SerializeField] GameObject mouse;

    public void Interact()
    {
        In();
    }

    private void In()
    {
        screenCamera.enabled = true;
        deskCamera.enabled = false;
        playerMovement.canInteract = false;

        phone.TryHangUp();
        onScreen = true;
    }

    private void Out()
    {
        screenCamera.enabled = false;
        deskCamera.enabled = true;
        playerMovement.canInteract = true;

        onScreen = false;
    }

    public void Update()
    {
        if (!onScreen)
        {
            return;
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Out();
        }

        MoveMouse();
    }

    public void MoveMouse()
    {
        var screenPoint = Input.mousePosition;
        screenPoint.z = 99.0f; //distance of the plane from the camera
        Vector3 pos = Camera.main.ScreenToWorldPoint(screenPoint);
        
        mouse.transform.localPosition = new Vector3(Input.mousePosition.x / Screen.width * 18f - 9f, Input.mousePosition.y / Screen.height * 10f - 5f, 99f);
    }
}
