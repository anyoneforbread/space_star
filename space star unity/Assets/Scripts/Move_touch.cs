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
    public int minLocation = 0;
    public int maxLocation = 0;
    public int currentLocation = 0;

    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            locations[i] = GameObject.Find(locName[i]);
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
            if (touch.deltaPosition.x > 0)
            {
                if (currentLocation < maxLocation)
                {
                    if (currentLocation == 0 && nextLevel.GetComponent<move_touch>().currentLocation == 0)
                    {
                        return;
                    }
                    moveUp();
                } else if (currentLocation == 0 && nextLevel.GetComponent<move_touch>().currentLocation == 1)
                {
                    moveUp();
                }
            }
            else if (touch.deltaPosition.x < 0)
            {
                if (currentLocation > minLocation)
                {
                    if (currentLocation == 5 && previousLevel.GetComponent<move_touch>().currentLocation == 5)
                    {
                        return;
                    }
                    moveDown();
                } else if (currentLocation == 5 && previousLevel.GetComponent<move_touch>().currentLocation == 4)
                {
                    moveDown();
                }
            }
        }
    }

    void moveUp()
    {
        if (transform.position.x >= locations[currentLocation + 1].GetComponent<Transform>().position.x)
        {
            currentLocation = currentLocation + 1;
            if (currentLocation == 5)
            {
                return;
            }
        }
        var step = mult * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, locations[currentLocation + 1].GetComponent<Transform>().position, step);
    }

    void moveDown()
    {
        if (transform.position.x <= locations[currentLocation - 1].GetComponent<Transform>().position.x)
        {
            currentLocation = currentLocation - 1;
            if (currentLocation == 0)
            {
                return;
            }
        }
        var step = mult * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, locations[currentLocation - 1].GetComponent<Transform>().position, step);
    }
}
