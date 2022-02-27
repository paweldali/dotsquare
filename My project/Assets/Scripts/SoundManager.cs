using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip playerJumpSound;
    static AudioSource audioSrc;

    void Start()
    {
        playerJumpSound = Resources.Load<AudioClip>("Sounds/playerJump");

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
        }
    }
}
