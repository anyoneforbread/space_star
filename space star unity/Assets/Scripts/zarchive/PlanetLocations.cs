using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetLocations : MonoBehaviour
{
    public List<Vector3> locations;

    void Awake()
    {
        locations = new List<Vector3>();
    }

    public void addPlanetLocation (Vector3 location)
    {
        locations.Add(location);
        foreach (var x in locations)
        {
            Debug.Log(x.ToString());
        }
    }

}
