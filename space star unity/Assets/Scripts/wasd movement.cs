using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class wasdmovement : MonoBehaviour
{
    public float moveSpeed = 5;


    void Start()
    {

    }


    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += UnityEngine.Vector3.right * moveSpeed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += UnityEngine.Vector3.right * -moveSpeed * Time.deltaTime;

        }

        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += UnityEngine.Vector3.up * moveSpeed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += UnityEngine.Vector3.up * -moveSpeed * Time.deltaTime;

        }
    }
}
