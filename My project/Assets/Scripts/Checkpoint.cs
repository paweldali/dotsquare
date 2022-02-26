using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    private PlayerLife player;
    void OnTriggerEnter2D(Collider2D checkpoint)
    {
        if (checkpoint.CompareTag("Player"))
        {
            gm.lastCheckPointPos = transform.position;
            Debug.Log("Checkpoint!");
            player.checkpointed = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
