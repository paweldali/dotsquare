using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishedLevelMenu : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    private int finishedLevelNumber;

    private float levelTime;

    private GameMaster gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        finishedLevelNumber = gm.levelNumber;
        levelTime = gm.levelTime;

        Debug.Log("Finished level " + finishedLevelNumber + "\n time = " + levelTime);

        textDisplay.text = "level " + finishedLevelNumber + " completed with " + System.Math.Round(levelTime, 2).ToString() + "s";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Level" + finishedLevelNumber);
    }

    public void PlayNextMap()
    {
        if(gm.numberOfLevels > finishedLevelNumber) {
            finishedLevelNumber++;
            gm.levelNumber++;
            SceneManager.LoadScene("Level" + finishedLevelNumber);
        }
        else {
            Debug.Log("There is no more levels");
            textDisplay.text = "There is no more levels. Or you can't find them? :)";
        }
    }
}
