using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_1level : MonoBehaviour
{
    private GameObject[] locations = new GameObject[6];
    private List<string> locName = new List<string>(new string[] { "Past", "Current", "Next 1", "Next 2", "Next 3", "Future" });
    public GameObject levels;
    private float mult = 10f;

    private int levelIndex;

    // Start is called before the first frame update
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
        
    }

    public void moveUp(int currentLocation)
    {
        if (transform.position.x >= locations[currentLocation + 1].GetComponent<Transform>().position.x)
        {
            currentLocation = currentLocation + 1;

            if (currentLocation == 1)
            {
                levels.GetComponent<Move_levels>().updateIndex(levelIndex);
            }
        }
        var step = mult * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, locations[currentLocation + 1].GetComponent<Transform>().position, step);
    }

    public void moveDown(int currentLocation)
    {
        if (transform.position.x <= locations[currentLocation - 1].GetComponent<Transform>().position.x)
        {
            currentLocation = currentLocation - 1;

            if (currentLocation == 1)
            {
                levels.GetComponent<Move_levels>().updateIndex(levelIndex);
            }
        }
        var step = mult * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, locations[currentLocation - 1].GetComponent<Transform>().position, step);
    }

    public void inputIndex(int lvlIndex)
    {
        levelIndex = lvlIndex;
    }
}
