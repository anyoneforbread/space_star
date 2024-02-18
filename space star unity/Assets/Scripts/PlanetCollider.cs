using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCollider : MonoBehaviour
{
    public float healthChange;
    public float fuelChange;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<RocketStats>().HealthChange(healthChange);
            other.GetComponent<RocketStats>().FuelChange(fuelChange);
        }
    }





}
