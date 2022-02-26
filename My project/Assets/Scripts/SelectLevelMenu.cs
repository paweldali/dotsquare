using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelMenu : MonoBehaviour
{
    // Start is called before the first frame update

    private GameMaster gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void SelectLevel(int levelNumber){
        gm.levelNumber = levelNumber;
        SceneManager.LoadScene("Level" + levelNumber);
    }

    public void SelectLevel(){
        Debug.Log("SelectLevel");
    }
}
