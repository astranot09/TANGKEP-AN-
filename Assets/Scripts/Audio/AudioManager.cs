using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioSource SFX;

    [SerializeField] private AudioClip bgmMusic;
    public AudioClip gainPoint;
    public AudioClip damage;

    private void Start()
    {
        PlayBGM(bgmMusic);
    }

    public void PlayBGM(AudioClip clip)
    {
        BGM.clip = clip;
        BGM.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
