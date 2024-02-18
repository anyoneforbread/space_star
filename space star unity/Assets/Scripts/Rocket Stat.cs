using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [HideInInspector] public float currentHealth;
    public HealthBar healthBar;
    [SerializeField] private float armour;



    [SerializeField] private float maxFuel;
    [HideInInspector] public float currentFuel;
    public FuelBar fuelBar;
    [SerializeField] private float fuelSaving;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setSliderMax(maxHealth);

        currentFuel = maxFuel;
        fuelBar.setSliderMax(maxFuel);
    }

    public void HealthChange(float amount)
    {
        if (amount < 0) amount += armour;
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetSlider(currentHealth);
        if (currentHealth <= 0) Die();
    }


    public void FuelChange(float amount)
    {
        if (amount < 0) amount += fuelSaving;
        currentFuel += amount;
        currentFuel = Mathf.Clamp(currentFuel, 0, maxHealth);
        fuelBar.SetSlider(currentFuel);
        if (currentFuel <= 0) Die();
    }



    public void Die()
    {
        Debug.Log("Youy Died!");
    }

}
