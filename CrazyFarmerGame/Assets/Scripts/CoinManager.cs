using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public SaveManager sm;
    [SerializeField] Text coinText;

    public int coinCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sm.data.CoinCount > -1)
        {
            coinText.text = ": " + coinCount.ToString();
        }

    }
}
