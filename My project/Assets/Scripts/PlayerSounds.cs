using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    // Start is called before the first frame update

    private bool grounded = false;
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;

        if (collision.gameObject.CompareTag("RedGround"))
        {
            print("red tground sound playin");
            SoundManager.PlaySound("dead");
        }



    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Finish"))
        {
            SoundManager.PlaySound("win");
        }
        else if (collider.CompareTag("Checkpoint"))
        {
            SoundManager.PlaySound("checkpoint");
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {   
            
            print("space key was pressed");
            SoundManager.PlaySound("jump");
        }
    }

    
}
