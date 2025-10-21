using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singleton
    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion
    public AudioSource musicChannel;
    public AudioSource sfxChannel;
    public AudioSource ambienceChannel;
    public AudioSource windChannel;
    public AudioSource enemyAudio;
    public AudioSource enemyMouth;

    public void StopAllSounds()
    {
        if(musicChannel != null)
        {
            musicChannel.volume = 0;
        }
        if (sfxChannel != null)
        {
            sfxChannel.volume = 0;
        }
        if (ambienceChannel != null)
        {
            ambienceChannel.volume = 0;
        }
        if (windChannel != null)
        {
            windChannel.volume = 0;
        }
    }
    public void PauseAllSounds()
    {
        if (musicChannel != null)
        {
            musicChannel.Pause();
        }
        if (sfxChannel != null)
        {
            sfxChannel.Pause();
        }
        if (ambienceChannel != null)
        {
            ambienceChannel.Pause();
        }
        if (windChannel != null)
        {
            windChannel.Pause();
        }
        if(enemyAudio != null)
        {
            enemyAudio.Pause();
        }
        if(enemyMouth != null)
        {
            enemyMouth.Pause();
        }
    }
    public void UnPauseAllSounds()
    {
        if (musicChannel != null)
        {
            musicChannel.Play();
        }
        if (sfxChannel != null)
        {
            sfxChannel.Play();
        }
        if (ambienceChannel != null)
        {
            ambienceChannel.Play();
        }
        if (windChannel != null)
        {
            windChannel.Play();
        }
        if (enemyAudio != null)
        {
            enemyAudio.Play();
        }
        if (enemyMouth != null)
        {
            enemyMouth.Play ();
        }
    }

    public void PlayOneShot(AudioClip clip)
    {
        sfxChannel.PlayOneShot(clip);
    }
    public void PlayOneShot(AudioSource source,AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
    public void PlayMusic(AudioClip clip)
    {
        musicChannel.clip = clip;
        musicChannel.Play();
    }
    public void PlayLoop(AudioSource source, AudioClip clip)
    {
        if(source.isPlaying)
        {
            return;
        }
        source.clip = clip;
        source.Play();
    }
    public void StopLoop(AudioSource source)
    {
        source.Stop();
        source.clip = null;
    }

    public void StopMusic()
    {
        musicChannel.Stop();
        musicChannel.clip = null;
    }
    public void FeedAudioSources(AudioSource enemy1,  AudioSource enemy2)
    {
        enemyMouth = enemy1;
        enemyAudio = enemy2;
    }
}
