using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{

    Levelgen LG;
    public float speed = 1f;
    [SerializeField] private float planetColliderHeight;
    private int index = 0;

    /*
        IEnumerator Start()
        {
            LG = GameObject.FindGameObjectWithTag("Planet Spawner").GetComponent<Levelgen>();
            yield return new WaitForEndOfFrame();
            List<Vector3> locations = LG.locations;
        }
    */
    public void move(int steps)
    {
        LG = GameObject.FindGameObjectWithTag("Planet Spawner").GetComponent<Levelgen>();
        List<Vector3> locations = LG.locations;

        for (int i = 0; i < steps; i++)
        {
            index += 1;
            if (index >= locations.Count)
            {
                index = locations.Count;
                Debug.Log("level finished");
                return;
            }

            else
            {
                Vector3 nextPos = new Vector3(locations[index][0], locations[index][1], transform.position.z);
                update(nextPos, speed);
                //transform.position = Vector3.Lerp(transform.position, nextPos, speed);
                Debug.Log(locations[index]);
            }
            land();
            Debug.Log(index);
        }
    }

    private void land()    //collide with collider
    {
        Vector3 currentPos = transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, planetColliderHeight);
        Debug.Log(transform.position);
        transform.position = currentPos;
        Debug.Log("landed");
    }

    private void update(Vector3 nextPos, float speed)
    {
        transform.position = Vector3.Lerp(transform.position, nextPos, speed);

    }

}
