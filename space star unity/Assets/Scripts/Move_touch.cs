using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_touch : MonoBehaviour
{
    private Touch touch;
    private Vector2 startPos;
    private Vector2 direction;
    private bool validMovement = false;
    public float mult = 1.0f;

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
                    //direction = touch.position - startPos;
                    //validMovement = (direction.x * direction.y) > 0 ? true : false;
                    validMovement = (touch.deltaPosition.x * touch.deltaPosition.y) > 0 ? true : false;
                    break;

                case TouchPhase.Ended:
                    validMovement = false;
                    break;
            }
            
            if (validMovement)
            {
                transform.position = new Vector3(
                transform.position.x + touch.deltaPosition.x * mult,
                transform.position.y + touch.deltaPosition.y * mult,
                transform.position.z);
            }
        }
    }
}
