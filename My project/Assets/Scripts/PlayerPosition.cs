using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public ParticleSystem dust;
    private GameMaster gm;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
    }

    // Update is called once per frame
    void Update()
    {   
       if(player.GetComponent<Rigidbody2D>().velocity.magnitude > 0){
            CreateDust();
        }
    }

//    private void OnCollisionEnter2D(Collision2D other) {
 //       if(other.gameObject.tag == "RedGround"){
 //           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
 //       }    
  //  }

    void CreateDust(){
        dust.Play();
    }
}
