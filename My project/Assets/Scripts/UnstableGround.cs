using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableGround : MonoBehaviour
{

    public float TimeToGoingDown = 1.5f;
    public float GravityAfterTimePlayerTouched = 1;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private bool _playerCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerCollided){
            TimeToGoingDown -= Time.deltaTime;
        }

        if(TimeToGoingDown < 0){
            _rigidbody.gravityScale = GravityAfterTimePlayerTouched;
            _spriteRenderer.color = Color.red;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerCollided = true;
            _spriteRenderer.color = Color.yellow;
        }
    }
}
