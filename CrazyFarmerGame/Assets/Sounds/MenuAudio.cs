using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    [Header("--------- Audio Source ---------")]
    [SerializeField] AudioSource musicSource;

    [Header("--------- Audio Clip ---------")]
    public AudioClip background;


    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
