using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    private GameMaster gm;

    void OnTriggerEnter2D(Collider2D finishLine)
    {
        if (finishLine.CompareTag("Player"))
        {
            gm.isLevelCompleted = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
