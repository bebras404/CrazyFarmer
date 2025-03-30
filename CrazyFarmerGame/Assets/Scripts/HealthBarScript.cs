using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

    [SerializeField] private Slider slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void UpdateHealthBar(float currentValue, float maxValue) 
    {
        slider.value = currentValue / maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
