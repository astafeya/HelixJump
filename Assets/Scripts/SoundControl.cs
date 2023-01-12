using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public AudioSource Background;
    public AudioSource BallBounce;
    public AudioSource PlatformBreak;
    public GameObject MuteIcon;
    public GameObject UnmuteIcon;

    private string SOUND_MUTE = "SoundMute";
    private string MUTE = "Mute";
    private string UNMUTE = "Unmute";

    public string SoundMute
    {
        get => PlayerPrefs.GetString(SOUND_MUTE, UNMUTE);
        private set
        {
            PlayerPrefs.SetString(SOUND_MUTE, value);
            PlayerPrefs.Save();
        }
    }

    private void Awake()
    {
        SetCorrectIconAndMute();
        Background.Play();
    }

    public void OnMuteButtonClick()
    {
        DoMute(!IsMute());
    }

    public bool IsMute()
    {
        return SoundMute == MUTE;
    }
    
    public void DoMute(bool value)
    {
        if (value) SoundMute = MUTE;
        else SoundMute = UNMUTE;
        SetCorrectIconAndMute();
    }

    private void SetCorrectIconAndMute()
    {
        SetCorrectSoundIcon();
        SetCorrectSoundMute();
    }

    private void SetCorrectSoundIcon()
    {
        if (IsMute())
        {
            MuteIcon.SetActive(true);
            UnmuteIcon.SetActive(false);
        } else
        {
            MuteIcon.SetActive(false);
            UnmuteIcon.SetActive(true);
        }
    }

    private void SetCorrectSoundMute()
    {
        bool mute = IsMute();
        Background.mute = mute;
        BallBounce.mute = mute;
        PlatformBreak.mute = mute;
    }

    public void PlayBallBounce()
    {
        BallBounce.Play();
    }

    public void PlayPlatformBreak()
    {
        PlatformBreak.Play();
    }
}
