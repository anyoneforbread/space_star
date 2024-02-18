using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public TextMeshProUGUI valueText;

    public void SetSlider(float amount)
    {
        healthSlider.value = amount;
        valueText.text = amount.ToString();
    }

    public void setSliderMax(float amount)
    {
        healthSlider.maxValue = amount;
        SetSlider(amount);
    }
}
