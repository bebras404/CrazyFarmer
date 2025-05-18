using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public SaveManager saveManager; // Assign this in Inspector

    public Button swordButton;
    public Button wandButton;
    public Button iceButton;

    public TextMeshProUGUI swordFeedback;
    public TextMeshProUGUI wandFeedback;
    public TextMeshProUGUI iceFeedback;

    private bool swordBought = false;
    private bool wandBought = false;
    private bool iceBought = false;

    private void Start()
    {
        //PlayerPrefs.DeleteKey("bought_sword");
        //PlayerPrefs.DeleteKey("bought_wand");
        //PlayerPrefs.DeleteKey("bought_ice");

        swordButton.onClick.AddListener(() => BuyItem("sword", 1, ref swordBought, swordButton, swordFeedback));
        wandButton.onClick.AddListener(() => BuyItem("wand", 1, ref wandBought, wandButton, wandFeedback));
        iceButton.onClick.AddListener(() => BuyItem("ice", 1, ref iceBought, iceButton, iceFeedback));

        LoadPurchaseStates();
    }

    void BuyItem(string itemKey, int cost, ref bool boughtFlag, Button button, TextMeshProUGUI feedback)
    {
        if (boughtFlag)
        {
            feedback.text = "Already bought!";
            return;
        }

        int currentCoins = saveManager.PassCoinCount();

        if (currentCoins == -1)
        {
            feedback.text = "Save not loaded!";
            Debug.LogWarning("Tried to buy " + itemKey + ", but no save was loaded.");
            return;
        }

        if (currentCoins >= cost)
        {
            currentCoins -= cost;
            saveManager.SetCoinCount(currentCoins);
            saveManager.SaveGame(); // Save after spending

            boughtFlag = true;
            PlayerPrefs.SetInt("bought_" + itemKey, 1);
            button.interactable = false;
            feedback.text = "Item bought!";
            Debug.Log(itemKey + " purchased for " + cost + " coins.");
        }
        else
        {
            feedback.text = "Not enough coins!";
            Debug.Log("Not enough coins for " + itemKey);
        }
    }

    void LoadPurchaseStates()
    { 
        if (PlayerPrefs.GetInt("bought_sword", 0) == 1)
        {
            swordBought = true;
            swordButton.interactable = false;
            swordFeedback.text = "Item bought!";
        }

        if (PlayerPrefs.GetInt("bought_wand", 0) == 1)
        {
            wandBought = true;
            wandButton.interactable = false;
            wandFeedback.text = "Item bought!";
        }

        if (PlayerPrefs.GetInt("bought_ice", 0) == 1)
        {
            iceBought = true;
            iceButton.interactable = false;
            iceFeedback.text = "Item bought!";
        }
    }
}
