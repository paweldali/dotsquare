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

        // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {   
            //in PlayerMovement is called on JumpButton
            Debug.Log("space key was pressed");
            SoundManager.PlaySound("jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;

        if (collision.gameObject.CompareTag("RedGround"))
        {
            SoundManager.PlaySound("dead");
        }
        else if (collision.gameObject.CompareTag("OrangeGround"))
        {
            SoundManager.PlaySound("superjump");
        }
        else if (collision.gameObject.CompareTag("GreenGround"))
        {
            SoundManager.PlaySound("superspeed");
        }



    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Finish"))
        {
            Debug.Log("finish sound play");
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



    
}
