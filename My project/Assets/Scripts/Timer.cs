using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float currentTime = 0f;

    [SerializeField] TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float getCurrentTime(){
        return currentTime;
    }


    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        
        if((currentTime - (int)currentTime == 0))  
            timerText.text = System.Math.Round(currentTime, 2).ToString() + ".00";
        else  
            timerText.text = System.Math.Round(currentTime, 2).ToString();
    }
}
