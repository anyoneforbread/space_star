using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RocketMovement : MonoBehaviour
{

    Levelgen LG;
    public float movementTime = 0.8f;
    [SerializeField] private float planetColliderHeight;
    private int index = 1;
    private Vector3 nextPos;
    public float coolDownTime = 1f; //move cooldown
    private bool coolDown = false;
    private float landTime = 0.01f;


    public void move(int steps)
    {
        if (coolDown == false)
        {
            LG = GameObject.FindGameObjectWithTag("Planet Spawner").GetComponent<Levelgen>();
            List<Vector3> locations = LG.locations;
            List<Vector3> path = new List<Vector3>(); //movement path

            if (index >= locations.Count)
            {
                index = locations.Count;
                Debug.Log("level finished");
                return;
            }


            while (index < locations.Count && steps > 0)
            {
                path.Add(new Vector3(locations[index][0], locations[index][1], transform.position.z));
                index += 1;
                steps -= 1;
            }
            Vector3[] pathArr = path.ToArray();
            transform.DOPath(pathArr, movementTime, PathType.CatmullRom).SetEase(Ease.OutCubic);


            /*
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
                    //moving = true;
                    //transform.position = Vector3.Lerp(transform.position, nextPos, speed);
                    transform.DOMove(nextPos, 2);
                    Debug.Log(locations[index]);
                } */
            Invoke("land", movementTime);
            Debug.Log(index);
            Invoke("ResetCooldown", coolDownTime);
            coolDown = true;
        }
        
     }
    

    private void land()    //collide with collider
    {
        Vector3 currentPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 target = new Vector3(transform.position.x, transform.position.y, planetColliderHeight);
        Vector3[] landArr = new [] {target, currentPos};
        transform.DOPath(landArr, landTime);
        Debug.Log(transform.position);
        Debug.Log("landed");
    }

    private void ResetCooldown()
    {
        coolDown = false;
    }

}
