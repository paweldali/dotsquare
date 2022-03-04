using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SelectLevelMenu : MonoBehaviour
{
    // Start is called before the first frame update

    private GameMaster gm;

    private float[] bestTimes;

    private GameObject levelDescriptionPanel;

    public TextMeshProUGUI levelNameTMP;
    public TextMeshProUGUI levelTimeTMP;
    
    
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        //best times info from SaveManager
        LoadSave();
    }

    public void LoadSave(){
        bestTimes = SaveManager.instance.bestTimes;
    }


    private int levelNumberPlayerChecks;
    public void SelectLevel(int levelNumber){
        // levelDescriptionPanel.SetActive(true);
        levelNameTMP.text = "LEVEL " + levelNumber;

        if(bestTimes[levelNumber-1] != 0f) //if value of level time is not empty
            levelTimeTMP.text = System.Math.Round(bestTimes[levelNumber-1], 2).ToString();
        else
            levelTimeTMP.text = "NONE";

        levelNumberPlayerChecks = levelNumber;
    }

    public void PlayLevel(){
        gm.levelNumber = levelNumberPlayerChecks;
        SceneManager.LoadScene("Level" + levelNumberPlayerChecks);
    }

}
