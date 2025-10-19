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
}
