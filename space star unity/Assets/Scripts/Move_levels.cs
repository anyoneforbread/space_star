using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_levels : MonoBehaviour
{
    public List<GameObject> levels;
    private int minIndex = 1;
    private int maxIndex;
    private int currentIndex = 1;
    private List<int> locations;

    private Touch touch;
    private bool validMovement = false;

    // Start is called before the first frame update
    void Start()
    {
        maxIndex = levels.Count - 5;

        for (int i = 0; i < levels.Count; i++)
        {
            int location = (i < 5) ? i : 5;
            locations.Add(location);
            levels[i].GetComponent<Move_1level>().inputIndex(i);
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
                if (currentIndex > minIndex)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        levels[currentIndex - 1 + i].GetComponent<Move_1level>().moveUp(i);
                    }
                }
            } else if (touch.deltaPosition.x < 0)
            {
                if (currentIndex < maxIndex)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        levels[currentIndex + i].GetComponent<Move_1level>().moveDown(i + 1);
                    }
                }
            }
        }
    }

    public void updateIndex(int newIndex)
    {
        currentIndex = newIndex;
    }
}
