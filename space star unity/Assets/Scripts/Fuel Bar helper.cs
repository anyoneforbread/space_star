using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FuelBar : MonoBehaviour
{
    public Slider fuelSlider;
    public TextMeshProUGUI valueText;

    public void SetSlider(float amount)
    {
        fuelSlider.value = amount;
        valueText.text = amount.ToString();
    }

    public void setSliderMax(float amount)
    {
        fuelSlider.maxValue = amount;
        SetSlider(amount);
    }
}
