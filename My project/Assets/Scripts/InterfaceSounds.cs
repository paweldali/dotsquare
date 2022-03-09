using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceSounds : MonoBehaviour
{

    public void PlayButtonSound(){
        SoundManager.PlaySound("button");
    }
}
