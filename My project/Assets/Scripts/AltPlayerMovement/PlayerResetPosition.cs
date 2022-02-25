using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerResetPosition : MonoBehaviour
{
    public Vector3 startPosition;




    void Awake()
    {
        startPosition = transform.position; // its talking about this gameobject
    }
    void FixedUpdate()
    {
        if (Input.GetKey("r"))
        {
            transform.position = startPosition;
            print("Reset Position");

        }
    }
}
