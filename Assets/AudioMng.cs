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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudioAmbient()
    {
        if (audioMusic.clip != clips[0])
        {
            audioMusic.Stop();
            audioMusic.clip = clips[0];
            audioMusic.Play();
        }
    }

    public void PlayAudioTerminal()
    {
        if (audioMusic.clip != clips[1])
        {
            audioMusic.Stop();
            audioMusic.clip = clips[1];
            audioMusic.Play();
        }
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
