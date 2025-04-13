using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public SaveManager sm;
    public float elapsedTime;
    [SerializeField] TextMeshProUGUI text;
    void Update()
    {

        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int secconds = Mathf.FloorToInt(elapsedTime % 60);
        string timerText = string.Format("Time: {0:00}:{1:00}", minutes, secconds);
        text.text = timerText.ToString();
        sm.SetPlayTime(elapsedTime);
    }
}
