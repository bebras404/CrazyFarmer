using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField] Text coinText;
    public SaveManager sm;
    private int coinCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (sm.PassCoinCount() != -1) 
        {
            coinCount = sm.PassCoinCount();
        }

    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = ": " + coinCount.ToString();
    }

    public void AddCoins(int amount) 
    {
        coinCount += amount;
        sm.SetCoinCount(coinCount);
    }
}
