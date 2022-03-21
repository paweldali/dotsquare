using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private GameMaster gm;
    void Start(){
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    public void PlayGame(){
        SaveManager.instance.levelsTries[gm.levelNumber - 1] += 1;
        SaveManager.instance.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + gm.levelNumber);
        
        //SceneManager.LoadScene("Level1");
        //SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
