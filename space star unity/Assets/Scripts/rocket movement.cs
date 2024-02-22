using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RocketMovement : MonoBehaviour
{

    Levelgen LG;
    public float fuelPerMove = 5f;
    public float movementTime = 0.8f;
    [SerializeField] private float planetColliderHeight;
    private int index = 1;
    private Vector3 nextPos;
    public float coolDownTime = 1f; //move cooldown
    private bool coolDown = false;
    private float landTime = 0.01f;
    RocketStats rocketStats;


    public void move(int steps)
    {
        if (coolDown == false)
        {
            LG = GameObject.FindGameObjectWithTag("Planet Spawner").GetComponent<Levelgen>();
            List<Vector3> locations = LG.locations;
            List<Vector3> path = new List<Vector3>(); //movement path
            float fuelConsumption = steps * fuelPerMove;
            rocketStats = GetComponent<RocketStats>();

            if (fuelConsumption > rocketStats.currentFuel)
            {
                Debug.Log("not enough fuel!!");
                return;

            }

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
            transform.DOPath(pathArr, movementTime, PathType.CatmullRom).SetEase(Ease.InOutCubic);

            rocketStats.FuelChange(-fuelConsumption);

            Invoke("land", movementTime);
            Debug.Log(index);
            Invoke("ResetCooldown", coolDownTime);
            if (fuelPerMove > rocketStats.currentFuel) rocketStats.Die();
            coolDown = true;
        }
        
     }
    

    private void land()    //collide with collider
    {
        Vector3 currentPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 target = new Vector3(transform.position.x, transform.position.y, planetColliderHeight);
        Vector3[] landArr = new [] {target, currentPos};
        transform.DOPath(landArr, landTime);

        Debug.Log("landed");
    }

    private void ResetCooldown()
    {
        coolDown = false;
    }

}
