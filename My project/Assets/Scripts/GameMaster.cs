using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;

    public Vector2 lastCheckPointPos;

    public bool isLevelCompleted = false; 

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
    }

    // Update is called once per frame
    void Update()
    {
       if(isLevelCompleted){
           Debug.Log("level completed!");
           isLevelCompleted = false;
       }
    }
}
