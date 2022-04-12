using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D PlayerRigidBody2D;
    [Range(0, 1)]
    public float smoothFactor;

    private void LateUpdate()
    {
        follow();
    }

    void follow()
    {
        Vector3 offset = cameraAHeadOfPlayer();
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor);
        transform.position = smoothPosition;
    }

    Vector3 cameraAHeadOfPlayer()
    {
        return new Vector3(0, offsetCount(PlayerRigidBody2D.velocity.y), -10);
    }

    private float offsetCount(float value)
    {
        if (value > 0.1f)
        {
            return System.Math.Min(1.5f, value);
        }
        else if (value < -0.1f)
        {
            return System.Math.Max(-1.5f, value);
        }
        else
        {
            return 0f;
        }
    }
}