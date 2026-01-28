using Assets.FootballGameEngine_Indie.Scripts.Managers;
using UnityEngine;

public class FarmsSettings : MonoBehaviour
{
    [Space(5)]
    public GameObject soundOn;
    public GameObject musicOn;

    private void Start()
    {
        soundOn.SetActive(FarmsApp.sound.Equals(1));
        musicOn.SetActive(FarmsApp.music.Equals(1));
        SoundManager.Instance.MusicVolume = FarmsApp.music.Equals(1) ? 1 : 0;
        SoundManager.Instance.SoundVolume = FarmsApp.sound.Equals(1) ? 1 : 0;
    }

    public void SetMusic()
    {
        if (FarmsApp.music.Equals(1))
        {
            FarmsApp.music = 0;
            SoundManager.Instance.MusicVolume = 0;
            //SoundsFarms.instance?.PauseMusic();
        }
        else
        {
            FarmsApp.music = 1;
            SoundManager.Instance.MusicVolume = 1;
            //SoundsFarms.instance?.PlayMusic();
        }
        musicOn.SetActive(FarmsApp.music.Equals(1));
        SoundsFarms.instance?.PlaySound(0);
    }

    public void SetSound()
    {
        if (FarmsApp.sound.Equals(1))
        {
            FarmsApp.sound = 0;
            SoundManager.Instance.SoundVolume = 0;
        }
        else
        {
            FarmsApp.sound = 1;
            SoundManager.Instance.SoundVolume = 1;
        }
        soundOn.SetActive(FarmsApp.sound.Equals(1));
        SoundsFarms.instance?.PlaySound(0);
    }
}