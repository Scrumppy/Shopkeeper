using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : BaseManager<AudioManager>
{
    [SerializeField] private Sound[] sfxSounds;
    [SerializeField] private Sound[] musicSounds;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;

    [SerializeField] private AudioClip[] footstepSounds;

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("Provided sound name does not exist");
            return;
        }
        else
        {
            musicSource.clip = sound.clip;
            musicSource.Play();
        }
    }

    public void PlaySound(string name, float pitch)
    {
        Sound sound = Array.Find(sfxSounds, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("Provided sound name does not exist");
            return;
        }
        else
        {
            sfxSource.pitch = pitch;
            sfxSource.PlayOneShot(sound.clip);
        }
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SoundVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public void PlayFootstepSounds()
    {
        if (footstepSounds.Length == 0) return;

        int randomIndex = Random.Range(0, footstepSounds.Length);
        sfxSource.clip = footstepSounds[randomIndex];
        sfxSource.Play();
    }

    public float GetMusicVolume() { return musicSource.volume; }
    public float GetSFXVolume() { return sfxSource.volume; }
}
