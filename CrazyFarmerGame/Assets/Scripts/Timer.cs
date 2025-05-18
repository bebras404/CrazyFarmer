using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public SaveManager sm;
    public float elapsedTime;
    [SerializeField] TextMeshProUGUI text;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        int hours = Mathf.FloorToInt(elapsedTime / 3600);
        int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        string timerText = string.Format("Time: {0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        text.text = timerText;

        double roundedHours = Math.Round(elapsedTime / 3600, 5);
        sm.SetPlayTime(roundedHours);
    }
}
