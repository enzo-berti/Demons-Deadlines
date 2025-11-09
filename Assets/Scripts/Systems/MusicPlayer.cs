using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private double goalTime;
    private double musicDuration;
    private AudioSource[] audioSource;

    private AudioClip currentClip;

    //private void OnPlayMusic()
    //{
    //    goalTime = AudioSettings.dspTime + 0.5;
    //    audioSource.PlayScheduled(goalTime);
    //
    //    musicDuration = (double)currentClip.samples / currentClip.frequency;
    //}
    //
    //private void Update()
    //{
    //    if (AudioSettings.dspTime > goalTime - 1)
    //    {
    //        PlayScheduledClip()
    //    }
    //}
    //
    //private void PlayScheduledClip()
    //{
    //    
    //}
}
