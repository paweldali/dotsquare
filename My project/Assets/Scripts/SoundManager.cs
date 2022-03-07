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
        audioSrc = GetComponent<AudioSource>();
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
        if(audioSrc != null) return audioSrc.clip.name;
        return "";
    }

    public int GetFullTrackLength(){
        _fullTrackLength = (int)audioSrc.clip.length;
        return _fullTrackLength;
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
