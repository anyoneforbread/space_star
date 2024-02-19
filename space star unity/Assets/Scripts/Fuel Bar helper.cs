using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FuelBar : MonoBehaviour
{
    public Slider fuelSlider;
    public TextMeshProUGUI valueText;
    [SerializeField] private float slidingTime = 0.1f;
    private float velocity;
    private float target;

    public void SetSlider(float amount)
    {
        //fuelSlider.value = amount;
        target = amount;
        valueText.text = amount.ToString();
    }

    public void setSliderMax(float amount)
    {
        fuelSlider.maxValue = amount;
        fuelSlider.value = amount;
        target = amount;
        valueText.text = amount.ToString();
    }

    void Update()
    {
        fuelSlider.value = Mathf.SmoothDamp(fuelSlider.value, target, ref velocity, slidingTime);
    }
}
