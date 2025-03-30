using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }  // Singleton

    [SerializeField] private TextMeshProUGUI timerText;
    private float elapsedTime = 0f;
    private float bestTime = 0f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            if (transform.parent == null) // Only prevent destruction if root object
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate Timers
        }
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("bestTime"))
        {
            bestTime = PlayerPrefs.GetFloat("bestTime");
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        if (timerText != null)
        {
            timerText.text = $"Time: {minutes:00}:{seconds:00}";
        }

        // Update best time if the current elapsed time is greater
        if (elapsedTime > bestTime)
        {
            bestTime = elapsedTime;
            PlayerPrefs.SetFloat("bestTime", bestTime);
            PlayerPrefs.Save();
        }
    }

    public void OnPlayerDeath()
    {
        //Debug.Log("Player died. Saving final time: " + elapsedTime);
        PlayerPrefs.SetFloat("finalTime", elapsedTime);
        PlayerPrefs.Save();
    }
}
