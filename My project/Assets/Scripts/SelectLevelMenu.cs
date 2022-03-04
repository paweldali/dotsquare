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
        bestTimes = SaveManager.instance.bestTimes;


        levelDescriptionPanel = GameObject.Find("LevelPopUp");
        

        SetBestLevelTimes();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }


    public void SelectLevel(int levelNumber){
        levelDescriptionPanel.SetActive(true);
        levelNameTMP.text = "LEVEL " + levelNumber;

        if(bestTimes[levelNumber-1] != null)
            levelTimeTMP.text = System.Math.Round(bestTimes[levelNumber-1], 2).ToString();
        else
            levelTimeTMP.text = "NONE";



        // gm.levelNumber = levelNumber;
        // SceneManager.LoadScene("Level" + levelNumber);
    }

    public void SelectLevel(){
        Debug.Log("SelectLevel");
    }


    //set best level times to TMPs in SelectLevelMenu
    private void SetBestLevelTimes(){
        // TextMeshProUGUI textField = (TextMeshProUGUI)GetComponents(typeof(Button))[1].GetComponents(typeof(TextMeshProUGUI))[1];
        // TextMeshProUGUI textField = (TextMeshProUGUI)GetComponent("Level1Button").GetComponents(typeof(TextMeshProUGUI))[1];

        // textField.text = "best time: " + bestTimes[0];

        Debug.Log("best time: " + bestTimes[0]);
    }
}
