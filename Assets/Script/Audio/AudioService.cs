using System.Collections.Generic;
using UnityEngine;

public class AudioService : GenericMonoSingleton<AudioService>
{
    [SerializeField] private AudioSource sfxAudioSource;
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioScriptableObject audioScriptableObject;
    [SerializeField] private bool isMute;

    private void Start()
    {
        PlayBackgroundMusic();
    }

    public void Play(SoundType soundType)
    {
        if (!isMute)
        {
            sfxAudioSource.PlayOneShot(GetSoundClip(soundType));
        }
    }

    public void PlayClickSound()
    {
        if (!isMute)
        {
            Play(SoundType.Click);
        }
    }

    public AudioClip GetSoundClip(SoundType Stype)
    {
        Sound sound = audioScriptableObject.audioList.Find(x => x.soundType == Stype);
        return sound.soundClip;
    }

    public void PlayBackgroundMusic()
    {
        if (!isMute)
        {
            AudioClip bgClip = GetSoundClip(SoundType.Background);
            if (bgClip != null)
            {
                sfxAudioSource.clip = bgClip;
                sfxAudioSource.loop = true;
                sfxAudioSource.Play();
            }
        }
    }

}

