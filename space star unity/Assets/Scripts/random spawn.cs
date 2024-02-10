using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomspawn : MonoBehaviour
{
    [SerializeField] private int TotPlanetNo;
    [SerializeField] private GameObject[] PlanetPrefab;
    [SerializeField] private float minY;  //dist btw planets
    [SerializeField] private float maxY;
    [SerializeField] private float StartY;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    

    void Start()
    {
        for (int i = 0; i < TotPlanetNo; i++)
        {
            float ranY = Random.Range(minY, maxY);
            float ranX = Random.Range(minX, maxX);
            Vector3 randposition = new Vector3(ranX, StartY, transform.position.z);
            Instantiate(PlanetPrefab[Random.Range(0, PlanetPrefab.Length)], randposition, Quaternion.identity);
            StartY += ranY;
        }
    }

    void Update()
    {
        
    }
}
