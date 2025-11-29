using UnityEngine;

public class AudioMng : MonoBehaviour
{
    public static AudioMng Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }
    [SerializeField] AudioSource audioMusic;
    [SerializeField] AudioSource audioVFX;
    [SerializeField] AudioClip[] clips;

    private bool isChangeMusic;
    private bool isLowVolumeMusic;
    private AudioClip currentClipMusic;

    void Update()
    {
        if (isChangeMusic == false) return;
        if(audioMusic.volume > 0 && isLowVolumeMusic == true)
        {
            audioMusic.volume -= 1 * Time.deltaTime;
            if (audioMusic.volume <= 0) {
                isLowVolumeMusic = false;
                audioMusic.Stop();
                audioMusic.clip = currentClipMusic;
                audioMusic.Play();
            }
        }
        else if (audioMusic.volume < 0.5 && isLowVolumeMusic == false)
        {
            audioMusic.volume += 1 * Time.deltaTime;
            if (audioMusic.volume >=1)
            {
                isLowVolumeMusic = true;
                isChangeMusic = false;
            }
        }
    }

    public void PlayAudioAmbient()
    {
        isChangeMusic = true;
        isLowVolumeMusic = true;
        currentClipMusic = clips[0];
    }

    public void PlayAudioTerminal()
    {
        isChangeMusic = true;
        isLowVolumeMusic = true;
        currentClipMusic = clips[1];
    }

    public void PlayAudioStepsSand()
    {
        audioVFX.PlayOneShot(clips[2]);
    }

    public void PlayAudioGun()
    {
        audioVFX.PlayOneShot(clips[3]);
    }

    public void PlayAudioDeathEnemy()
    {
        audioVFX.PlayOneShot(clips[4]);
    }

    public void PlayAudioClickUI()
    {
        audioVFX.PlayOneShot(clips[5]);
    }

    public void PlayAudioExtrationPoint()
    {
        audioVFX.PlayOneShot(clips[6]);
    }
}
