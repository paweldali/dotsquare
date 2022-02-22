using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class DiscoBackground : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public bool isHardDiscoAlreadyStarted = false;

    public bool isRandomColorOnEachSceneReload = true;

    void Start()
    {   
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if(isRandomColorOnEachSceneReload) randomBackgroundColor();
    }

    void randomBackgroundColor(){
        spriteRenderer.color = new Color(
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f)
         );
    }

    void Update()
    {
        if(isHardDiscoAlreadyStarted) randomBackgroundColor();
    }
}
