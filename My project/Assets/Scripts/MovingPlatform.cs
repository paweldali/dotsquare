using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;



    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    //update is called once per frame
    void Update()
    {
        

        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
           //  Debug.Log("pos1reached");
        }
        if(transform.position == pos2.position)
        {
            nextPos = pos1.position;
           // Debug.Log("pos2reached");
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

    }
       
   

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

}