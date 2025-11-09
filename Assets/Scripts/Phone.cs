using UnityEngine;
using UnityEngine.Audio;

public class Phone : MonoBehaviour
{
    [SerializeField] private GameObject playerPhone;
    [SerializeField] private GameObject cosmeticPhone;
    [SerializeField] private PhoneText phoneText;

    [SerializeField] private AudioClip hangClip;
    [SerializeField] private AudioClip ringingClip;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private MainTheme mainTheme;

    public bool canPeekUp = false;

    public void Awake()
    {
        Ring();
    }

    public void Ring()
    {
        canPeekUp = true;
        audioSource.clip = ringingClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void Interact()
    {
        bool hasPhone = playerPhone.activeSelf;

        if (hasPhone)
        {
            mainTheme.IncreaseVolume();
            TryHangUp();
        }
        else
        {
            mainTheme.DecreaseVolume();
            TryPeekUp();
        }

        audioSource.Play();
        playerPhone.SetActive(!playerPhone.activeSelf);
        cosmeticPhone.SetActive(!cosmeticPhone.activeSelf);
    }

    private void TryPeekUp()
    {
        audioSource.loop = false;
        audioSource.clip = hangClip;

        if (canPeekUp && phoneText)
        {
            phoneText.StartPhoneCall();
            mainTheme.NextTheme();

            canPeekUp = false;
        }
    }

    public void TryHangUp()
    {
        audioSource.loop = false;
        audioSource.clip = hangClip;

        if (!phoneText.CanHangUp())
        {
            return;
        }

        canPeekUp = true;
    }
}
