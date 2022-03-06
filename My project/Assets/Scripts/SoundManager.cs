using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;


// [RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    static SoundManager instance = null;

    public TextMeshProUGUI TitleDisplayerTMP;
    public TextMeshProUGUI TimeDisplayerTMP;

    // Start is called before the first frame update
    public static AudioClip playerJumpSound,
                            dead1, dead2, dead3, dead4, dead5,
                            win1, win2, win3, win4, win5,
                            checkpoint1;

    public AudioClip[] musicClips;
    static AudioSource audioSrc;
    private int _currentTrack;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        playerJumpSound = Resources.Load<AudioClip>("Sounds/playerJump");

        dead1 = Resources.Load<AudioClip>("Sounds/dead1");
        dead2 = Resources.Load<AudioClip>("Sounds/dead2");
        dead3 = Resources.Load<AudioClip>("Sounds/dead3");
        dead4 = Resources.Load<AudioClip>("Sounds/dead4");
        dead5 = Resources.Load<AudioClip>("Sounds/dead5");

        win1 = Resources.Load<AudioClip>("Sounds/win1");
        win2 = Resources.Load<AudioClip>("Sounds/win2");

        checkpoint1 = Resources.Load<AudioClip>("Sounds/checkpoint1");

        audioSrc = GetComponent<AudioSource>();

        PlayMusic();
    }

    public void PlayMusic()
    {
        if (audioSrc.isPlaying)
        {
            return;
        }

        _currentTrack--;
        if (_currentTrack < 0)
        {
            _currentTrack = musicClips.Length - 1;
        }

        StartCoroutine("WaitForMusicEnd");
    }

    IEnumerator WaitForMusicEnd()
    {
        while (audioSrc.isPlaying)
        {
            _playTime = (int) audioSrc.time;
            ShowPlayTime();
            yield return null;
        }
        NextTitle();
    }

    public void NextTitle()
    {
        audioSrc.Stop();
        _currentTrack++;

        if (_currentTrack > musicClips.Length - 1)
        {
            _currentTrack = 0;
        }

        audioSrc.clip = musicClips[_currentTrack];
        audioSrc.Play();
        ShowCurrentTitle();


        //show title

        StartCoroutine("WaitForMusicEnd");
    }

    public void PreviousTitle()
    {
        audioSrc.Stop();
        _currentTrack--;

        if (_currentTrack < 0)
        {
            _currentTrack = musicClips.Length - 1;
        }

        audioSrc.clip = musicClips[_currentTrack];
        audioSrc.Play();
        ShowCurrentTitle();

        //show title

        StartCoroutine("WaitForMusicEnd");
    }

    public void StopMusic(){
        StopCoroutine("WaitForMusicEnd");
        audioSrc.Stop();
    }

    public void MuteMusic(){
        audioSrc.mute = !audioSrc.mute;
    }


    private int _fullTrackLength;
    private int _playTime;
    private int _seconds;
    private int _minutes;

    void ShowCurrentTitle(){
        TitleDisplayerTMP.text = audioSrc.clip.name;
        _fullTrackLength = (int) audioSrc.clip.length;
    }

    void ShowPlayTime(){
        _seconds = _playTime % 60;
        _minutes = (_playTime / 60) % 60;
        TimeDisplayerTMP.text = _minutes + ":" + _seconds.ToString("D2") + "/" + ((_fullTrackLength/60) % 60) + ":" + (_fullTrackLength%60).ToString("D2");
    }
    

    //slider
    void SetVolume(float sliderValue){
        
    }

    // Update is called once per frame
    void Update()
    {
    }



    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.volume = 0.15f;
                audioSrc.PlayOneShot(playerJumpSound);
                break;
            case "dead":
                audioSrc.volume = 1.0f;
                int randomClipNumber = Random.Range(0, 5 + 1);

                switch (randomClipNumber)
                {
                    case 1:
                        audioSrc.PlayOneShot(dead1);
                        break;
                    case 2:
                        audioSrc.PlayOneShot(dead2);
                        break;
                    case 3:
                        audioSrc.PlayOneShot(dead3);
                        break;
                    case 4:
                        audioSrc.PlayOneShot(dead4);
                        break;
                    case 5:
                        audioSrc.PlayOneShot(dead5);
                        break;

                }
                break;
            case "win":
                audioSrc.volume = 1.0f;

                int randomClipNumber2 = Random.Range(1, 2 + 1);

                Debug.Log("win audio playin " + randomClipNumber2);
                // audioSrc.PlayOneShot(win1);
                // audioSrc.PlayOneShot(win2);
                Debug.Log("win");

                switch (randomClipNumber2)
                {
                    case 1:
                        audioSrc.PlayOneShot(win1);
                        break;
                    case 2:
                        audioSrc.PlayOneShot(win2);
                        break;
                }
                break;
            case "checkpoint":
                audioSrc.volume = 0.25f;
                audioSrc.PlayOneShot(checkpoint1);
                break;

            default:
                // audioSrc.PlayOneShot(dead4); //haha
                break;

        }
    }



}
