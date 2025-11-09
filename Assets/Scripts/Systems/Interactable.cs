using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public int DefaultLayer { get; private set; } = 0;

    public UnityEvent interactEvent;

    void Awake()
    {
        DefaultLayer = gameObject.layer;
    }
    
    public void Play()
    {
        interactEvent.Invoke();
    }

}
