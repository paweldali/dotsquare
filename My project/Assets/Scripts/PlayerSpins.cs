using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpins : MonoBehaviour
{
    public float xAngle = 0, yAngle = 0, zAngle = 0, zRotate = 0;

    private GameObject playerCube;

    // Start is called before the first frame update
    void Start()
    {
        playerCube = GameObject.Find("Player");
    }

    bool CheckIsPlayerSpin()
    {
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        //playerCube.transform.Rotate(xAngle, yAngle, +zRotate, Space.Self);
    }
}
