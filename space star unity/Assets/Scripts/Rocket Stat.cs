using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setSliderMax(maxHealth);
    }

    public void HealthChange(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        healthBar.SetSlider(currentHealth);
        if (currentHealth <= 0) Die();
    }

    public void Die()
    {
        Debug.Log("Youy Died!");
    }

}
