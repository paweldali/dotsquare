using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    private GameMaster gm;
    private PlayerLife player;

    void OnTriggerEnter2D(Collider2D finishLine)
    {
        if (finishLine.CompareTag("Player"))
        {
            gm.isLevelCompleted = true;
            player.checkpointed = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
    }
}
