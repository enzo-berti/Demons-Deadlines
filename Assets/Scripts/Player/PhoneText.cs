using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PhoneText : MonoBehaviour
{
    [SerializeField]
    [TextArea]
    private List<string> _dialogueLines;
    private int _lineIndex = 0;

    [SerializeField] private PlayerMovement playerMovement;

    private TMP_Text _text;
    public CanvasGroup _group;

    private bool isPlaying = false;

    [SerializeField]
    private List<AudioClip> phoneClips;
    [SerializeField] private AudioSource phoneAudio;
    [SerializeField] private AudioSource phoneMusic;

    [SerializeField] private AudioClip hangPhone;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _group.alpha = 0;
    }

    private void OnValidate()
    {
        if (_dialogueLines.Count > 0)
        {
            if (_text == null)
            {
                _text = GetComponent<TMP_Text>();
            }
            _text.SetText(_dialogueLines[0]);
        }
    }

    public void StartPhoneCall()
    {
        _text.SetText(_dialogueLines[_lineIndex]);
        phoneAudio.clip = phoneClips[_lineIndex];
        _group.alpha = 1;
        _lineIndex++;
        phoneAudio.Play();
        playerMovement.canInteract = false;
        isPlaying = true;
        phoneMusic.Play();
    }

    public bool CanHangUp()
    {
        return !phoneAudio.isPlaying;
    }

    private void StopDialogue()
    {
        _group.alpha = 0;
        playerMovement.canInteract = true;
        phoneMusic.Stop();
        phoneAudio.clip = hangPhone;
        phoneAudio.Play();
        isPlaying = false;
    }

    private void Update()
    {
        if (isPlaying && Mouse.current.leftButton.wasPressedThisFrame && !phoneAudio.isPlaying)
        {
            StopDialogue();
        }
    }
}
