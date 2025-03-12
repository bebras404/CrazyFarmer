using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    [Header("--------- Audio Source ---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip ---------")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip wallTouch;
    public GameObject player;

    private bool hasPlayedDeathSFX = false;

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
