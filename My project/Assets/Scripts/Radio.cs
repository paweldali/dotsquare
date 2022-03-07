using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Radio : MonoBehaviour
{

    private SoundManager _soundManager;

    public TextMeshProUGUI TitleDisplayerTMP;
    public TextMeshProUGUI TimeDisplayerTMP;

    public Slider VolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>(); 
        // ShowCurrentTitle();
    }

    // Update is called once per frame
    void Update()
    {
        ShowCurrentTitle();
        ShowPlayTime();
        VolumeSlider.value = _soundManager.GetVolumeLevel();
    }

    public void PlayMusic(){
        _soundManager.PlayMusic();
        _playTime = _soundManager.GetPlayTime();
        ShowCurrentTitle();
    }

    public void StopMusic(){
        _soundManager.StopMusic();
    }

    public void PlayNextTrack(){
        _soundManager.NextTitle();
        ShowCurrentTitle();
    }

    public void PlayPrevTrack(){
        _soundManager.PreviousTitle();
        ShowCurrentTitle();
    }

    public void MuteMusic(){
        _soundManager.MuteMusic();
    }

    public void SetVolume(float sliderValue){
        _soundManager.SetVolume(sliderValue);
    }


    private int _fullTrackLength;
    private int _playTime;
    private int _seconds;
    private int _minutes;
    void ShowCurrentTitle()
    {
        TitleDisplayerTMP.text = _soundManager.GetCurrentTitle();
        
    }

    void ShowPlayTime()
    {
        _fullTrackLength = _soundManager.GetFullTrackLength();
        _playTime = _soundManager.GetPlayTime();
        _seconds = _playTime % 60;
        _minutes = (_playTime / 60) % 60;
        TimeDisplayerTMP.text = _minutes + ":" + _seconds.ToString("D2") + "/" + ((_fullTrackLength / 60) % 60) + ":" + (_fullTrackLength % 60).ToString("D2");
    }

}
