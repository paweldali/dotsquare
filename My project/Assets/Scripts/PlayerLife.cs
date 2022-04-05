using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private GameMaster gm;

    [SerializeField] ParticleSystem deadParticle = null;
    [SerializeField] ParticleSystem speedBoostParticle = null;
    [SerializeField] ParticleSystem jumpBoostParticle = null;
    [SerializeField] ParticleSystem groundCollisionParticle = null;
    [SerializeField] ParticleSystem speedSlowParticle = null;

    private Timer timer;

    public bool checkpointed;

    // Start is called before the first frame update
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        gm.startPos = transform.position;
        // Debug.Log("Start pos = " + gm.startPos);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        checkpointed = false;
    }
    // Update is called once per frame
    public void Update()
    {
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
    private void PurpleWeaker()
    {
        Debug.Log("purple animation");
        anim.SetTrigger("Purple");
        speedSlowParticle.Play();
    }

    private void OrangeJumper()
    {
        Debug.Log("oragne animation");
        anim.SetTrigger("Orange");
        jumpBoostParticle.Play();
    }

    private void GreenBooster()
    {
        Debug.Log("green booster animation");
        anim.SetTrigger("Green");
        speedBoostParticle.Play();
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");

        Debug.Log("ded");

        // GetComponent<ParticleSystem>().Play();
        // ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        // em.enabled = true;

        deadParticle.Play();

    }

    private void RevivePlayer()
    {
        SaveManager.instance.levelsTries[gm.levelNumber - 1] += 1; //number of level tries++
        SaveManager.instance.Save();
        if (checkpointed)
            transform.position = gm.lastCheckPointPos;
        else
            transform.position = gm.startPos;
        Debug.Log("Player is alive");
        rb.bodyType = RigidbodyType2D.Dynamic;
        if (!checkpointed)
        {
            timer = GameObject.Find("Main Camera").GetComponent<Timer>(); //after player death scene is destroyed, so this cant be in start()
            timer.currentTime = 0f;
        }
    }
}