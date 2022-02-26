using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private GameMaster gm;

    private Timer timer;

    public bool checkpointed;

    // Start is called before the first frame update
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        gm.startPos = transform.position;

        Debug.Log("Start pos = " + gm.startPos);

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        checkpointed = false;
    }

    // Update is called once per frame
    public void Update(){
        if (Input.GetKey("r"))
        {
            checkpointed = false;
            gm.lastCheckPointPos = gm.startPos;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RedGround"))
        {
            Die();
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Idle();
        }
        else if (collision.gameObject.CompareTag("GreenGround"))
        {
            GreenBooster();
        }
        else if (collision.gameObject.CompareTag("PurpleGround"))
        {
            PurpleWeaker();
        }
        else if (collision.gameObject.CompareTag("OrangeGround"))
        {
            OrangeJumper();
        }
    }

    private void Idle(){
        Debug.Log("idle");
        anim.ResetTrigger("Green"); 
        anim.SetTrigger("Idle"); 
    }

    private void PurpleWeaker(){
        Debug.Log("purple animation");
        anim.ResetTrigger("Idle"); 
        anim.SetTrigger("Purple"); 
    }

    private void OrangeJumper(){
        Debug.Log("oragne animation");
        anim.ResetTrigger("Idle"); 
        anim.SetTrigger("Orange"); 
    }

    private void GreenBooster(){
        Debug.Log("green booster animation");
        anim.ResetTrigger("Idle"); 
        anim.SetTrigger("Green"); 
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
        transform.position =  gm.lastCheckPointPos;
        anim.SetTrigger("Alive");
   

        Debug.Log("Player is alive");

        anim.ResetTrigger("Alive");



        anim.SetTrigger("Idle");
        rb.bodyType = RigidbodyType2D.Dynamic;
        if(!checkpointed)
        {
            timer = GameObject.Find("Main Camera").GetComponent<Timer>(); //after player death scene is destroyed, so this cant be in start()
            timer.currentTime = 0f;
        }
 
    }
}