using System.Diagnostics;
using UnityEngine;

[ExecuteInEditMode]
public class ParallaxLayer : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxFactor;

    public void Move(float delta)
    {
        UnityEngine.Vector3 newPos = transform.localPosition;
        newPos.y -= delta * parallaxFactor;

        transform.localPosition = newPos;
    }

    void Start()
    {
        startpos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
        //UnityEngine.Debug.Log($"length: {length}");
        //UnityEngine.Debug.Log($"startpos: {startpos}");
    }

    void FixedUpdate()
    {
        float temp = (cam.transform.position.y * (1-parallaxFactor));
        transform.position = new Vector3(transform.position.x, startpos, transform.position.z);
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
        
        UnityEngine.Debug.Log($"temp: {temp}");
        UnityEngine.Debug.Log($"startpos: {startpos}");
    }

}

