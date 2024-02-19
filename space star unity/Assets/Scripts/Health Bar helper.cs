using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private float slidingTime = 0.1f;
    private float velocity;
    private float target;

    public void SetSlider(float amount)
    {
        //healthSlider.value = amount;
        target = amount;
        valueText.text = amount.ToString();
    }

    public void setSliderMax(float amount)
    {
        healthSlider.maxValue = amount;
        healthSlider.value = amount;
        target = amount;
        valueText.text = amount.ToString();
    }

    void Update()
    {
        healthSlider.value = Mathf.SmoothDamp(healthSlider.value, target, ref velocity, slidingTime);
    }

}
