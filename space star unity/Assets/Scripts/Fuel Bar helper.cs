using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public Slider fuelSlider;

    public void SetSlider(float amount)
    {
        fuelSlider.value = amount;
    }

    public void setSliderMax(float amount)
    {
        fuelSlider.maxValue = amount;
        SetSlider(amount);
    }
}
