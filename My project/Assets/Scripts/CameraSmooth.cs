using UnityEngine;

public class CameraSmooth : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(0,10)]
    public float smoothFactor;




    private void LateUpdate() 
    {
        follow();
    }

    void follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}