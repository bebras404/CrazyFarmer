using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    [Header("--------- Audio Source ---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip ---------")]
    public AudioClip background;
    public AudioClip death;
    //public AudioClip wallTouch;
    public GameObject player;

    public static Audiomanager instance;

    private bool hasPlayedDeathSFX = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        musicSource.volume = 0.1f;
    }

    private void Update()
    {
       
        if (player.GetComponent<PlayerHealth>().health <= 0 && !hasPlayedDeathSFX)
        {
            SFXSource.PlayOneShot(death);
            musicSource.Stop();
            hasPlayedDeathSFX = true;
        }
    }
}
