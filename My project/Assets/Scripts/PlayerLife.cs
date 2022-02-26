using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private GameMaster gm;

    // Start is called before the first frame update
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RedGround"))
        {
            Die();
        }
    }

    private void Die()
    {
       anim.SetTrigger("Death"); 
       rb.bodyType = RigidbodyType2D.Static;
    }

    private void KillPlayer()
    {
        anim.ResetTrigger("Idle"); 
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        RevivePlayer();
    }

    private void RevivePlayer(){
        anim.ResetTrigger("Death"); 


        
        anim.SetTrigger("Alive");
        transform.position =  gm.lastCheckPointPos;

        Debug.Log("Player is alive");

        anim.ResetTrigger("Alive");

        rb.bodyType = RigidbodyType2D.Dynamic;

        anim.SetTrigger("Idle");

        

        
    }
}