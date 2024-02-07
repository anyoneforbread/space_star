using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_touch : MonoBehaviour
{
    private Touch touch;
    private Vector2 startPos;
    private bool validMovement = false;
    public float mult = 1.0f;

    private GameObject[] locations = new GameObject[6];
    private List<string> locName = new List<string>(new string[] { "Past", "Current", "Next 1", "Next 2", "Next 3", "Future" });
    public GameObject previousLevel;
    public GameObject nextLevel;
    private Vector3[] distance = new Vector3[5];
    public int minLocation = 0;
    public int maxLocation = 0;
    public int currentLocation = 0;

    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            locations[i] = GameObject.Find(locName[i]);
        }
        for (int i = 0; i < 5; i++)
        {
            distance[i] = new Vector3(
                locations[i+1].GetComponent<Transform>().position.x - locations[i].GetComponent<Transform>().position.x,
                locations[i+1].GetComponent<Transform>().position.y - locations[i].GetComponent<Transform>().position.y,
                locations[i+1].GetComponent<Transform>().position.z - locations[i].GetComponent<Transform>().position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    validMovement = (touch.deltaPosition.x * touch.deltaPosition.y) > 0 ? true : false;
                    break;

                case TouchPhase.Ended:
                    validMovement = false;
                    break;
            }
        }

        if (validMovement)
        {
            if (touch.deltaPosition.x > 0 && (currentLocation < maxLocation || maxLocation == -1))
            {
                transform.position = new Vector3(
                    transform.position.x + distance[currentLocation].x * mult,
                    transform.position.y + distance[currentLocation].y * mult,
                    transform.position.z + distance[currentLocation].z * mult);
            }
            else if (touch.deltaPosition.x < 0 && (currentLocation > minLocation || minLocation == -1))
            {
                transform.position = new Vector3(
                    transform.position.x - distance[currentLocation-1].x * mult,
                    transform.position.y - distance[currentLocation-1].y * mult,
                    transform.position.z - distance[currentLocation-1].z * mult);
            }
        }
    }
}
