using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;

    [SerializeField] Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        currentTime = (float)System.Math.Round(currentTime, 2);
        Debug.Log(currentTime);
        timerText.text = currentTime.ToString();
    }
}
