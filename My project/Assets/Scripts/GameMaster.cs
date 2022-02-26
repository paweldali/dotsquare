using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;

    public Vector2 lastCheckPointPos;

    public Vector2 startPos;

    public bool isLevelCompleted = false; 

    public float levelTime;

    public int levelNumber = 1;

    public int numberOfLevels = 2;

    private Timer timer;


    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

        //timer = GameObject.Find("Timer").GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
       if(isLevelCompleted){
           timer = GameObject.Find("Main Camera").GetComponent<Timer>(); //after player death scene is destroyed, so this cant be in start()
           levelTime = timer.getCurrentTime();
           Debug.Log("level" + levelNumber +  "completed with time:" + levelTime.ToString());

           SceneManager.LoadScene("FinishedLevel");

           isLevelCompleted = false;
       }
    }
}
