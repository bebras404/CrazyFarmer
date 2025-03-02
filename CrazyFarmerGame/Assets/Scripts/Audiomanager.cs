using JetBrains.Annotations;
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

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        musicSource.volume = 0.1f;
    }
}
