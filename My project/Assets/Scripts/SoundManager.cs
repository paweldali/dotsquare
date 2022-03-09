using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;


// [RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;


    // Start is called before the first frame update
    public static AudioClip playerJumpSound, playerSuperJumpSound, playerSuperSpeedSound,
                            dead1, dead2, dead3, dead4, dead5,
                            win1, win2, win3, win4, win5,
                            checkpoint1, 
                            button1, button2, button3, button4, button5, button6, button7, button8, button9;

    public AudioClip[] musicClips;
    static AudioSource audioSrc;

    public AudioSource playerAudioSrc;
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
        audioSrc = GetComponent<AudioSource>();
    }

    void Start()
    {
        playerJumpSound = Resources.Load<AudioClip>("Sounds/playerJump");
        playerSuperJumpSound = Resources.Load<AudioClip>("Sounds/playerSuperJump");
        playerSuperSpeedSound = Resources.Load<AudioClip>("Sounds/playerSuperSpeed");

        dead1 = Resources.Load<AudioClip>("Sounds/dead1");
        dead2 = Resources.Load<AudioClip>("Sounds/dead2");
        dead3 = Resources.Load<AudioClip>("Sounds/dead3");
        dead4 = Resources.Load<AudioClip>("Sounds/dead4");
        dead5 = Resources.Load<AudioClip>("Sounds/dead5");

        win1 = Resources.Load<AudioClip>("Sounds/win1");
        win2 = Resources.Load<AudioClip>("Sounds/win2");

        checkpoint1 = Resources.Load<AudioClip>("Sounds/checkpoint1");

        button1 = Resources.Load<AudioClip>("Sounds/Interface/buttonClick1");
        button2 = Resources.Load<AudioClip>("Sounds/Interface/buttonClick2");
        button3 = Resources.Load<AudioClip>("Sounds/Interface/buttonClick3");
        button4 = Resources.Load<AudioClip>("Sounds/Interface/buttonClick4");
        button5 = Resources.Load<AudioClip>("Sounds/Interface/buttonClick5");
        button6 = Resources.Load<AudioClip>("Sounds/Interface/buttonClick6");
        button7 = Resources.Load<AudioClip>("Sounds/Interface/buttonClick7");
        button8 = Resources.Load<AudioClip>("Sounds/Interface/buttonClick8");
        button9 = Resources.Load<AudioClip>("Sounds/Interface/buttonClick9");

        audioSrc = GetComponent<AudioSource>();

        PlayMusic();
    }

    void Update()
    {
        if (audioSrc == null) 
        {
            audioSrc = GetComponent<AudioSource>();
        }
    }

    public void PlayMusic()
    {
        if (audioSrc.isPlaying)
        {
            return;
        }

        instance._currentTrack--;
        if (instance._currentTrack < 0)
        {
            instance._currentTrack = instance.musicClips.Length - 1;
        }

        instance.StartCoroutine("WaitForMusicEnd");
    }

    public bool GetIsPlaying(){
        return audioSrc.isPlaying;
    }

    public void StopMusic()
    {
        instance.StopCoroutine("WaitForMusicEnd");
        audioSrc.Stop();
    }

    public float GetVolumeLevel(){
        return audioSrc.volume;
    }

    IEnumerator WaitForMusicEnd()
    {
        while (audioSrc.isPlaying)
        {
            _playTime = (int)audioSrc.time;
            // ShowPlayTime();
            yield return null;
        }
        NextTitle();
    }

    public int GetPlayTime(){
        return _playTime;
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
        // ShowCurrentTitle();


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
        // ShowCurrentTitle();

        //show title

        StartCoroutine("WaitForMusicEnd");
    }

    public string GetCurrentTitle(){

        if(audioSrc is not null && audioSrc.clip is not null) return audioSrc.clip.name;
        return musicClips[0].name;

    }

    public int GetFullTrackLength(){
        if(audioSrc is not null && audioSrc.clip is not null)
        {
            _fullTrackLength = (int)audioSrc.clip.length;
            return _fullTrackLength;
        }
        return (int)musicClips[0].length;
    }




    public void MuteMusic()
    {
        audioSrc.mute = !audioSrc.mute;
    }


    private int _fullTrackLength;
    private int _playTime;
    private int _seconds;
    private int _minutes;


    //slider
    public void SetVolume(float sliderValue)
    {

        audioSrc.volume = sliderValue;
    }


    public static void PlaySound(string clip)
    {
        int randomClipNumber;
        switch (clip)
        {
            case "jump":
                Debug.Log("jumper sound");
                audioSrc.PlayOneShot(playerJumpSound);
                break;
            case "superjump":
                Debug.Log("superjumper sound");
                audioSrc.PlayOneShot(playerSuperJumpSound);
                break;
            case "superspeed":
                audioSrc.PlayOneShot(playerSuperSpeedSound);
                break;
            case "dead":
                randomClipNumber = Random.Range(0, 5 + 1);

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

                randomClipNumber = Random.Range(1, 2 + 1);

                switch (randomClipNumber)
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
                audioSrc.PlayOneShot(checkpoint1);
                break;
            case "button":
                randomClipNumber = Random.Range(1, 9 + 1);

                switch (randomClipNumber)
                {
                    case 1:
                        audioSrc.PlayOneShot(button1);
                        break;
                    case 2:
                        audioSrc.PlayOneShot(button2);
                        break;
                    case 3:
                        audioSrc.PlayOneShot(button3);
                        break;
                    case 4:
                        audioSrc.PlayOneShot(button4);
                        break;
                    case 5:
                        audioSrc.PlayOneShot(button5);
                        break;
                    case 6:
                        audioSrc.PlayOneShot(button6);
                        break;
                    case 7:
                        audioSrc.PlayOneShot(button7);
                        break;
                    case 8:
                        audioSrc.PlayOneShot(button8);
                        break;
                    case 9:
                        audioSrc.PlayOneShot(button9);
                        break;
                }
                break;

            default:
                // audioSrc.PlayOneShot(dead4); //haha
                break;

        }
    }



}
