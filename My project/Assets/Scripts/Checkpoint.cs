using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    private PlayerLife player;
    private SpriteRenderer _spriteRenderer;
    void OnTriggerEnter2D(Collider2D checkpoint)
    {
        if (checkpoint.CompareTag("Player"))
        {
            gm.lastCheckPointPos = transform.position;
            Debug.Log("Checkpoint!");
            player.checkpointed = true;
            _spriteRenderer.color = Color.white;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
