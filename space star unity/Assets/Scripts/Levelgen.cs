using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class PlanetStat
{
    public GameObject PlanetPrefab;
    [Range(0f, 100f)] public float Chance = 100f;
    [HideInInspector] public double _weight;
}



public class Levelgen : MonoBehaviour
{
    [SerializeField] private int TotPlanetNo;
    [SerializeField] private PlanetStat[] Planets;
    [SerializeField] private float minY;  //dist btw planets
    [SerializeField] private float maxY;
    [SerializeField] private float StartY;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    public List<Vector3> locations = new List<Vector3>(); // first location is player origin

    private double accumulatedWeight;
    private System.Random rand = new System.Random();

    planetLineMaker lineMaker;

    void Awake()
    {
        CalcWeight();
    }

    void Start()
    {
        Vector3 playerLoc = GameObject.FindGameObjectWithTag("Player").transform.position;
        locations.Add(new Vector3(playerLoc.x, playerLoc.y, 0));

        for (int i = 0; i < TotPlanetNo; i++)
        {
            float ranY = Random.Range(minY, maxY);
            float ranX = Random.Range(minX, maxX);
            Vector3 randposition = new Vector3(ranX, StartY, transform.position.z);
            PlanetStat randPlanet = Planets[GetRandPlanetIndex()];
            Instantiate(randPlanet.PlanetPrefab, randposition, Quaternion.identity);
            locations.Add(new Vector3(ranX, StartY, 1));  //add to planet list, z units behind the planets
            StartY += ranY;

            
        }

        Vector3[] locationsArray = locations.ToArray();

        lineMaker = GameObject.FindGameObjectWithTag("Line").GetComponent<planetLineMaker>();
        lineMaker.draw(TotPlanetNo + 1, locationsArray); //+1 for player location

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
        foreach (PlanetStat planet in Planets)
        {
            accumulatedWeight += planet.Chance;
            planet._weight = accumulatedWeight;
        }
    }
}
