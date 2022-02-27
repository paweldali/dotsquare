using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    static SoundManager instance = null;

    // Start is called before the first frame update
    public static AudioClip playerJumpSound, 
                            dead1, dead2, dead3, dead4, dead5,
                            win1, win2, win3, win4, win5,
                            checkpoint1;
    static AudioSource audioSrc;

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

        win1 = Resources.Load<AudioClip>("Sounds/dead1");
        win2 = Resources.Load<AudioClip>("Sounds/dead2");

        checkpoint1 = Resources.Load<AudioClip>("Sounds/checkpoint1");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public static void PlaySound(string clip){
        switch(clip){
            case "jump": 
                audioSrc.volume = 0.15f;
                audioSrc.PlayOneShot(playerJumpSound);
                break;
            case "dead":
                audioSrc.volume = 1.0f;
                int randomClipNumber = Random.Range(0, 5); 
                
                switch(randomClipNumber){
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
                int randomClipNumber2 = Random.Range(1, 2); 
                // audioSrc.PlayOneShot(win1);
                // audioSrc.PlayOneShot(win2);
                Debug.Log("win");
                
                switch(randomClipNumber2){
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
