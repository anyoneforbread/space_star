using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float maxFuel;

    [HideInInspector] public float currentHealth;
    [HideInInspector] public float currentFuel;

    public HealthBar healthBar;
    public FuelBar fuelBar;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setSliderMax(maxHealth);

        currentFuel = maxFuel;
        fuelBar.setSliderMax(maxFuel);
    }

    public void HealthChange(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        healthBar.SetSlider(currentHealth);
        if (currentHealth <= 0) Die();
    }


    public void FuelChange(float amount)
    {
        currentFuel += amount;
        if (currentFuel > maxFuel) currentFuel = maxFuel;
        fuelBar.SetSlider(currentFuel);
        if (currentFuel <= 0) Die();
        Debug.Log(currentFuel);
    }


    public void Die()
    {
        Debug.Log("Youy Died!");
    }

}
