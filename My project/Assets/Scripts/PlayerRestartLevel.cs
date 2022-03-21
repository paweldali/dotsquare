using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerRestartLevel : MonoBehaviour
{
    public Vector3 startPosition;

    private PlayerLife Player;
    private GameMaster gm;

    private int _numberOfCurrentLevelRestarts = 0;


    void Awake()
    {
        startPosition = transform.position; // its talking about this gameobject
    }

    void Start()
    {
        // gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        // Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
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
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Player.checkpointed = false;

        Debug.Log("restarted level " + gm.levelNumber + "  ,attempts = " + SaveManager.instance.levelsTries[gm.levelNumber-1]);
        SaveManager.instance.levelsTries[gm.levelNumber-1] +=1;
        SaveManager.instance.Save();
        Debug.Log("attempts = " + SaveManager.instance.levelsTries[gm.levelNumber-1]);
    }
}
