using System.Collections;
using System.Linq;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    [Header("--------- Audio Source ---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip ---------")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip SingleJump;
    public AudioClip DoubleJump;
    public AudioClip Coin;
    public AudioClip PlayerHurt;
    public AudioClip Health;
    public AudioClip ScoreSound;
    public AudioClip[] FireBallSounds;
    public AudioClip MeleeAttack;
    public GameObject player;
    public AudioClip BearAttack;
    public AudioClip WolfAttack;
    public AudioClip EagleAttack;

    private bool hasPlayedDeathSFX = false;


    private AudioClip normalizedBackgroundClip;


    private void Start()
    {
        normalizedBackgroundClip = NormalizeAudio(background);

        musicSource.clip = normalizedBackgroundClip;
        musicSource.volume = 0.1f;
        musicSource.Play();
    }

    private void Update()
    {
       
        if (player.GetComponent<PlayerHealth>() != null && player.GetComponent<PlayerHealth>().health <= 0 && !hasPlayedDeathSFX)
        {
            SFXSource.PlayOneShot(death);
            musicSource.Stop();
            hasPlayedDeathSFX = true;
        }
        
    }
    private void Awake()
    {
        SFXSource.volume = 0.5f;
    }

    public void PlayAIAttackSound(GameObject obj) 
    {
        switch (obj.name) 
        {
            case ("MiniBear(Clone)"):
                SFXSource.PlayOneShot(BearAttack);
                break;
            case ("MiniWolf(Clone)"):
                SFXSource.PlayOneShot(WolfAttack);
                break;
            case ("MiniEagle(Clone)"):
                SFXSource.PlayOneShot(EagleAttack);
                break;
            default:
            Debug.LogWarning("Unknown AI object: " + obj.name);
            break;
        }
    }


    public void PlayMeleeAttackSound()
    {
        if (SFXSource != null && MeleeAttack != null)
        {
            SFXSource.PlayOneShot(MeleeAttack);
        }
    }

    public void PlayerFireballSound() 
    {
        int randomIndex = Random.Range(0, FireBallSounds.Count());
        if (SFXSource != null && FireBallSounds[randomIndex] != null)
        {
            SFXSource.PlayOneShot(FireBallSounds[randomIndex]);
        }
    }

    public void PlayCoinSound()
    {
        if (SFXSource != null && Coin != null)
        {
            SFXSource.PlayOneShot(Coin);
        }
    }

    public void PlayPlayerHurtSound()
    {
        if (SFXSource != null && PlayerHurt != null)
        {
            SFXSource.PlayOneShot(PlayerHurt);
        }
    }

    public void PlayHealthSound()
    {
        if (SFXSource != null && Health != null)
        {
            SFXSource.PlayOneShot(Health);
        }
    }

    public void PlayScoreSound()
    {
        if (SFXSource != null && ScoreSound != null)
        {
            SFXSource.PlayOneShot(ScoreSound);
        }
    }

    public void PlaySingleJumpSound()
    {
        if (SFXSource != null && SingleJump != null)
        {
            SFXSource.PlayOneShot(SingleJump);
        }
    }

    public void PlayDoubleJumpSound()
    {
        if (SFXSource != null && DoubleJump != null)
        {
            SFXSource.PlayOneShot(DoubleJump);
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
