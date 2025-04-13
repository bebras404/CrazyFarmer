using UnityEngine;
using System.IO;
using UnityEditor.Overlays;

public class SaveManager : MonoBehaviour
{
    private string SavePath;
    public SaveData data = new SaveData();

    private void Awake()
    {
        SavePath = Application.persistentDataPath + "/GameSave.json";
        LoadSave();
    }

    public void SaveGame() 
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(SavePath, json);
        Debug.Log("Game saved at: " + SavePath);
    }

    public void LoadSave() 
    {
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath);
            data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Game loaded.");
        }
        else 
        {
            Debug.Log("No save file yet.");
        }
    }

}

[System.Serializable]
public class SaveData
{
    public int CoinCount;
    public long HighScore;
    public float PlayTime;
}

