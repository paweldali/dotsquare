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
    public float Zoom2 = 50.0f;

    public float Speed = 0.01f;

    void Start()
    {
        Cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(ZoomActive){
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 10, Speed);
        }
        else
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 20, Speed);
    }
}
