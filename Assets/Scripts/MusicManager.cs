using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;
    public static MusicManager Instance => _instance;

    private AudioSource audioSource;

    // �u an �almakta olan m�zi�in bilgisi
    public AudioClip CurrentTrack => audioSource.clip;

    // M�zik oynat�l�yor mu kontrol�
    public bool IsPlaying => audioSource.isPlaying;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip[] tracks)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            Debug.Log("M�zik durduruldu.");
        }
        else
        {
            audioSource.clip = tracks[0];
            audioSource.Play();
            Debug.Log("M�zik ba�lat�ld�.");
        }
    }

    public void PlayRandomTrack(AudioClip[] tracks)
    {
        AudioClip randomTrack = tracks[Random.Range(0, tracks.Length)];
        audioSource.clip = randomTrack;
        audioSource.Play();
    }
}
