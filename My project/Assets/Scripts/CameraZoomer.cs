using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomer : MonoBehaviour
{
    public bool ZoomActive = true;

    public PlayerMovement playerMovement;

    public Vector3[] Target;

    public Camera Cam;

    public float Zoom1 = 12.0f;
    public float Zoom2 = 24.0f;

    public float Speed = 0.00065f;

    public float PlayerVelocityValueToZoomOut = 50.0f;

    void Start()
    {
        Cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(playerMovement.GetComponent<Rigidbody2D>().velocity.x + " " +  playerMovement.GetComponent<Rigidbody2D>().velocity.y);

        if(playerMovement.GetComponent<Rigidbody2D>().velocity.x > PlayerVelocityValueToZoomOut || playerMovement.GetComponent<Rigidbody2D>().velocity.y > PlayerVelocityValueToZoomOut){
            ZoomActive = false;
        }
        else if(playerMovement.GetGrounded()){
            ZoomActive = true;
        }


        if(ZoomActive){
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 10, Speed);
        }
        else
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 20, Speed);
    }
}
