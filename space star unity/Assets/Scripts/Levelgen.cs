using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlanetWeight
{
    public GameObject PlanetPrefab;
    [Range(0f, 100f)] public float Chance = 100f;
    [HideInInspector] public double _weight;
}



public class Levelgen : MonoBehaviour
{
    [SerializeField] private int TotPlanetNo;
    [SerializeField] private PlanetWeight[] Planets;
    [SerializeField] private float minY;  //dist btw planets
    [SerializeField] private float maxY;
    [SerializeField] private float StartY;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    private double accumulatedWeight;
    private System.Random rand = new System.Random();

    void Awake()
    {
        CalcWeight();
    }

    void Start()
    {
        for (int i = 0; i < TotPlanetNo; i++)
        {
            float ranY = Random.Range(minY, maxY);
            float ranX = Random.Range(minX, maxX);
            Vector3 randposition = new Vector3(ranX, StartY, transform.position.z);
            PlanetWeight randPlanet = Planets[GetRandPlanetIndex()];
            Instantiate(randPlanet.PlanetPrefab, randposition, Quaternion.identity);
            StartY += ranY;
        }
    }


    private int GetRandPlanetIndex()
    {
        double r = rand.NextDouble() * accumulatedWeight;
        for (int i = 0; i < Planets.Length; i++)
        {
            if (Planets[i]._weight >= r)
                return i;
        }
        return 0;
    }

    private void CalcWeight()
    {
        accumulatedWeight = 0f;
        foreach (PlanetWeight planet in Planets)
        {
            accumulatedWeight += planet.Chance;
            planet._weight = accumulatedWeight;
        }
    }
}
