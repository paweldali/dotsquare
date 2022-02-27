using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip playerJumpSound, 
                            dead1, dead2, dead3, dead4, dead5;
    static AudioSource audioSrc;

    void Start()
    {
        playerJumpSound = Resources.Load<AudioClip>("Sounds/playerJump");

        dead1 = Resources.Load<AudioClip>("Sounds/dead1");
        dead2 = Resources.Load<AudioClip>("Sounds/dead2");
        dead3 = Resources.Load<AudioClip>("Sounds/dead3");
        dead4 = Resources.Load<AudioClip>("Sounds/dead4");
        dead5 = Resources.Load<AudioClip>("Sounds/dead5");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip){
        switch(clip){
            case "jump": 
                audioSrc.PlayOneShot(playerJumpSound);
                break;
            case "dead":
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
            default:
                audioSrc.PlayOneShot(dead4); //haha
                break;

        }
    }



}
