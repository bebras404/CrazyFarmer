using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public CoinManager cm;
    
    public int CoinsToAdd = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            Destroy(this.gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
