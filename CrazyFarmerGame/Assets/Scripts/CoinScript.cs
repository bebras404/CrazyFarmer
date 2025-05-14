using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public CoinManager cm;
    
    public int CoinsToAdd = 1;

    private Audiomanager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("SFXAudio").GetComponent<Audiomanager>();
    }

    public void SetCM(CoinManager cm) 
    {
        this.cm = cm;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cm.AddCoins(CoinsToAdd);
            audioManager.PlayCoinSound();
            Destroy(this.gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
