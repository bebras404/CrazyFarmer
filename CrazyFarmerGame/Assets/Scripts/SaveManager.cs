using UnityEngine;
using System.IO;
using UnityEditor.Overlays;

public class SaveManager : MonoBehaviour
{
    private string SavePath;
    private bool SaveCreated = false;

    private SaveData data = new SaveData();


    private void Awake()
    {
        SavePath = Application.persistentDataPath + "/GameSave.json";
        LoadSave();
    }

    public void SetCoinCount(int amount) 
    {
        data.CoinCount = amount;
    }

    public void SetScoreCount(long amount)
    {
        data.HighScore = amount;
    }

    public void SetPlayTime(int PlayTime) 
    {
        data.PlayTime = PlayTime;
    }

    public int PassCoinCount() 
    {
        if (SaveCreated) 
        {
            return data.CoinCount;
        }
        return -1;
        
    }

    public long PassHighScore()
    {
        if (SaveCreated)
        {
            return data.HighScore;
        }
        return -1;
    }


    public float PassPlayTime() 
    {
        if (SaveCreated)
        {
            return data.PlayTime;
        }
        return -1;
    }



    public void SaveGame() 
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(SavePath, json);
        SaveCreated = true;
        Debug.Log("Game saved at: " + SavePath);
    }

    public void LoadSave() 
    {
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath);
            data = JsonUtility.FromJson<SaveData>(json);
            SaveCreated = true;
            Debug.Log("Game loaded.");
        }
        else 
        {
            Debug.Log("No save file yet.");
        }
    }

    public void Update()
    {

    }

}

[System.Serializable]
public class SaveData
{
    public int CoinCount;
    public long HighScore;
    public float PlayTime;
}

