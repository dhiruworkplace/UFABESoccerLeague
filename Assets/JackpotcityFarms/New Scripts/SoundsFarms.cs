using UnityEngine;

public class SoundsFarms : MonoBehaviour
{
    public static SoundsFarms instance;

    [SerializeField] private AudioSource a_music;
    [SerializeField] private AudioSource a_sound;

    [SerializeField] private AudioClip[] sounds;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (a_music != null && FarmsApp.music.Equals(1))
            a_music.Play();
    }

    public void PauseMusic()
    {
        if (a_music != null)
            a_music.Pause();
    }

    public void PlaySound(int index)
    {
        if (a_sound != null && FarmsApp.sound.Equals(1))
            a_sound.PlayOneShot(sounds[index]);
    }

    public void PlaySound(int index, bool loop)
    {
        if (a_sound != null && !a_sound.isPlaying)
            a_sound.PlayOneShot(sounds[index]);
    }

    public void StopSound()
    {
        a_sound.Stop();
    }
}