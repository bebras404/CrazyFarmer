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

    private bool hasPlayedDeathSFX = false;

    private AudioClip normalizedDeathClip;
    private AudioClip normalizedBackgroundClip;

    private void Start()
    {
        // Normalize both clips at start
        normalizedDeathClip = NormalizeAudio(death);
        normalizedBackgroundClip = NormalizeAudio(background);

        musicSource.clip = normalizedBackgroundClip;
        musicSource.Play();
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
    private AudioClip NormalizeAudio(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogWarning("AudioClip is null.");
            return null;
        }

        float[] samples = new float[clip.samples * clip.channels];
        clip.GetData(samples, 0);

        float max = 0f;
        foreach (float sample in samples)
        {
            float abs = Mathf.Abs(sample);
            if (abs > max) max = abs;
        }

        if (max <= 0f)
        {
            Debug.LogWarning("AudioClip has no audio data.");
            return clip;
        }

        float multiplier = 1f / max;
        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] *= multiplier;
        }

        AudioClip normalizedClip = AudioClip.Create(clip.name + "_normalized", clip.samples, clip.channels, clip.frequency, false);
        normalizedClip.SetData(samples, 0);
        return normalizedClip;
    }
}
