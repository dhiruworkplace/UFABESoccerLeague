using Assets.UFABESoccerLeague.Scripts.Managers;
using UnityEngine;

public class SoccerbetSettings : MonoBehaviour
{
    [Space(5)]
    public GameObject soundOn;
    public GameObject musicOn;

    private void Start()
    {
        soundOn.SetActive(SoccerbetApp.sound.Equals(1));
        musicOn.SetActive(SoccerbetApp.music.Equals(1));
        SoundManager.Instance.MusicVolume = SoccerbetApp.music.Equals(1) ? 1 : 0;
        SoundManager.Instance.SoundVolume = SoccerbetApp.sound.Equals(1) ? 1 : 0;
    }

    public void SetMusic()
    {
        if (SoccerbetApp.music.Equals(1))
        {
            SoccerbetApp.music = 0;
            SoundManager.Instance.MusicVolume = 0;
            SoundsSoccerbet.instance?.PauseMusic();
        }
        else
        {
            SoccerbetApp.music = 1;
            SoundManager.Instance.MusicVolume = 1;
            SoundsSoccerbet.instance?.PlayMusic();
        }
        musicOn.SetActive(SoccerbetApp.music.Equals(1));
        SoundsSoccerbet.instance?.PlaySound(0);
    }

    public void SetSound()
    {
        if (SoccerbetApp.sound.Equals(1))
        {
            SoccerbetApp.sound = 0;
            SoundManager.Instance.SoundVolume = 0;
        }
        else
        {
            SoccerbetApp.sound = 1;
            SoundManager.Instance.SoundVolume = 1;
        }
        soundOn.SetActive(SoccerbetApp.sound.Equals(1));
        SoundsSoccerbet.instance?.PlaySound(0);
    }
}