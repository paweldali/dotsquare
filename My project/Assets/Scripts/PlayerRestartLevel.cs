using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerRestartLevel : MonoBehaviour
{
    public Vector3 startPosition;
    
    private PlayerLife player;


    void Awake()
    {
        startPosition = transform.position; // its talking about this gameobject
    }

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
    }
    void FixedUpdate()
    {
        if (Input.GetKey("r"))
        {
            RestartLevel();
        }
    }
    public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            player.checkpointed = false;
        }
}
