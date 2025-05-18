using UnityEngine;
using TMPro;
using System.IO;

public class Stats : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI playTimeText;
    public TextMeshProUGUI highScoreText;

    private string savePath;

    void Start()
    {
        savePath = Application.persistentDataPath + "/GameSave.json";

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            coinText.text = "Coins: " + data.CoinCount.ToString();
            highScoreText.text = "High Score: " + data.HighScore.ToString();
            playTimeText.text = "Play Time: " + FormatTime(data.PlayTime);
        }
        else
        {
            coinText.text = "Coins: 0";
            highScoreText.text = "High Score: 0";
            playTimeText.text = "Play Time: 0:00";
        }
    }

    string FormatTime(double totalSeconds)
    {
        int minutes = Mathf.FloorToInt((float)totalSeconds / 60f);
        int seconds = Mathf.FloorToInt((float)totalSeconds % 60f);
        return minutes + ":" + seconds.ToString("D2");
    }
}
