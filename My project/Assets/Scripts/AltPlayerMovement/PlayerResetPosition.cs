using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
