using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetLineMaker : MonoBehaviour
{
    public LineRenderer line;


    void Start()
    {
        
    }

    public void draw(int planetNo,Vector3[] planetLocs)
    {
        line.positionCount = planetNo;
        line.SetPositions(planetLocs);
    }
}
