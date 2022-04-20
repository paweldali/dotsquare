using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;
using System.Data;


public class SelectLevelMenu : MonoBehaviour
{
    // Start is called before the first frame update

    private GameMaster gm;

    private float[] bestTimes;
    private int[] levelsTries;

    public GameObject levelDescriptionPanel;

    public TextMeshProUGUI levelNameTMP;
    public TextMeshProUGUI levelTimeTMP;
    public TextMeshProUGUI levelTriesTMP;
    public TextMeshProUGUI CalculatorDisplayTMP;

    public TextMeshProUGUI ButtonText;

    private List<string> scenesNames = new List<string>();
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        //best times info from SaveManager
        LoadSave();



        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            int lastSlash = scenePath.LastIndexOf("/");
            scenesNames.Add(scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".") - lastSlash - 1));
            // Debug.Log(scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".") - lastSlash - 1));
        }

    }

    public void LoadLevelByTileButton(){
        int loadLevel = Int32.Parse(ButtonText.text);
        gm.levelNumber = loadLevel;

        SaveManager.instance.levelsTries[loadLevel - 1] += 1;
        SaveManager.instance.Save();

        SceneManager.LoadScene("Level" + Convert.ToString(loadLevel));
        Debug.Log("Level" + Convert.ToString(loadLevel));
    }

    public void LoadSave()
    {
        bestTimes = SaveManager.instance.bestTimes;
        levelsTries = SaveManager.instance.levelsTries;
    }


    private int levelNumberPlayerChecks;
    public void SelectLevel(int levelNumber)
    {
        if(levelNumber > bestTimes.Length || levelNumber < 0) return;

        levelNameTMP.text = "LEVEL " + levelNumber;

        Debug.Log("besttimes size = " + bestTimes.Length);

        if (bestTimes[levelNumber - 1] != 0f) //if value of level time is not empty
            levelTimeTMP.text = System.Math.Round(bestTimes[levelNumber - 1], 2).ToString();
        else
            levelTimeTMP.text = "NONE";

        levelNumberPlayerChecks = levelNumber;

        levelTriesTMP.text = levelsTries[levelNumber - 1].ToString();


        levelDescriptionPanel.SetActive(false);
        foreach (string sceneName in scenesNames)
        {
            if (sceneName == ("Level" + levelNumber)){
                levelDescriptionPanel.SetActive(true);
                break;
            } 
        }
    }

    public void PlayLevel()
    {
        gm.levelNumber = levelNumberPlayerChecks;
        Debug.Log("Level" + Convert.ToString(levelNumberPlayerChecks));

        SaveManager.instance.levelsTries[levelNumberPlayerChecks - 1] += 1;
        SaveManager.instance.Save();

        SceneManager.LoadScene("Level" + Convert.ToString(levelNumberPlayerChecks));
    }

    private string equation = "";
    DataTable dt = new DataTable();
    public void Calculator(string clickedButton)
    {

        equation += clickedButton;

        CalculatorDisplayTMP.text = equation;
    }

    public void Reset() {
        equation = "";
        CalculatorDisplayTMP.text = equation;
    }

    public void Calculate()
    {
        if(equation == "") return;

        try{
            var v = dt.Compute(equation, "");
            equation = "";
            CalculatorDisplayTMP.text = Convert.ToString(v);
            SelectLevel(Convert.ToInt32(v));
        }catch(OverflowException e){
            CalculatorDisplayTMP.text = "81G NUMB3R, T00 81G";
            throw e;
        }catch(SyntaxErrorException e){
            CalculatorDisplayTMP.text = "3RR0R";
            throw e;
        }

        
    }

}
