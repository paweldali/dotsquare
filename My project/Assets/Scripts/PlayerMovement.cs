using UnityEngine;
using UnityEngine.UI;
using EasyJoystick;


public class PlayerMovement : MonoBehaviour
{

    // public Joystick Joystick;

    [SerializeField] private Joystick2 _joystick;

    public float MovementSpeed = 1;
    public float JumpForce = 40;

    // private float _jumpTimeCounter;
    // public float JumpTime = 0.35f;
    public float SpeedMultiplier = 2;

    public float SpeedDivider = 2;

    public float TrampolineJumpBoost = 1.5f;
    private Rigidbody2D _rigidbody;

    private bool _isAlive = true;
    private bool _isSpeedBoosted = false;
    private bool _isSpeedSlowed = false;
    private float _timeToJumpEnterCollision = 0.5f; //works as time to jump after leaving collision 
    private bool _redGrounded = false;
    private bool _grounded = false;

    // Start is called before the first frame update
    private void Start()
    {

        _joystick.ArrowKeysSimulationEnabled = true;
        _rigidbody = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame

    private void Update()
    {

        var movement = _joystick.Horizontal();
        // JOYSTICK
        // var movement = 0f;

        // if(IsJoystick){ //JOYSTICK
        //     movement = _joystick.Horizontal();
        // }
        // else{ //KEYBOARD
        //     movement = Input.GetAxis("Horizontal");
        // }

        if (_isAlive)
        {
            //KEYBOARD
            if (_isSpeedBoosted)
            {
                _rigidbody.velocity = new Vector2(movement * MovementSpeed * SpeedMultiplier, _rigidbody.velocity.y);
            }
            else if (_isSpeedSlowed)
            {
                _rigidbody.velocity = new Vector2(movement * MovementSpeed / SpeedDivider, _rigidbody.velocity.y);
            }
            else
            {
                _rigidbody.velocity = new Vector2(movement * MovementSpeed, _rigidbody.velocity.y);
            }

        }

        if (_timeToJumpEnterCollision > 0)
        {
            _timeToJumpEnterCollision -= Time.deltaTime;
        }

        //jump
        if ((Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.01f) || (Input.GetButtonDown("Jump") && _timeToJumpEnterCollision > 0))
        {
            _timeToJumpEnterCollision = 0;
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            Debug.Log("jumper");
        }
    }

    public void JumpButton()
    {
        if ((Mathf.Abs(_rigidbody.velocity.y) < 0.01f) || (_timeToJumpEnterCollision > 0))
        {
            _timeToJumpEnterCollision = 0;
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);


            SoundManager.PlaySound("jump");
        }
        // Debug.Log("jumper2");
    }


    public bool GetRedGrounded()
    {
        return _redGrounded;
    }

    public bool GetGrounded()
    {
        return _grounded;
    }

    //detect collision with other objects
    void OnCollisionEnter2D(Collision2D collision)
    {
        _timeToJumpEnterCollision = 0.5f;
        _grounded = true;
        
        if (collision.gameObject.CompareTag("RedGround")) //ded
        {
            _redGrounded = true;

            _isAlive = false;
            _isSpeedBoosted = false;
            _isSpeedSlowed = false;
        }
        else if (collision.gameObject.CompareTag("Ground")) //normal
        {
            _isAlive = true;
            _isSpeedBoosted = false;
            _isSpeedSlowed = false;

            // Debug.Log("entered ground");
        }
        else if (collision.gameObject.CompareTag("GreenGround")) //speed booster
        {
            _isAlive = true;
            _isSpeedBoosted = true;
            _isSpeedSlowed = false;

            // Debug.Log("GreenGround");
        }
        else if (collision.gameObject.CompareTag("OrangeGround")) //trampoline
        {
            _timeToJumpEnterCollision = 0f;

            _isAlive = true;
            _isSpeedBoosted = false;
            _isSpeedSlowed = false;


            _rigidbody.AddForce(new Vector2(0, JumpForce * TrampolineJumpBoost), ForceMode2D.Impulse);
        }
        else if (collision.gameObject.CompareTag("PurpleGround"))
        { //slowing 
            _isAlive = true;
            _isSpeedBoosted = false;
            _isSpeedSlowed = true;
        }
        // else if (collision.gameObject.CompareTag("Marshmallow"))
        // {
        //     // Debug.Log("entered Marshmallow");
        // }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        _grounded = false;
        _redGrounded = false;
        // if (collision.gameObject.CompareTag("Marshmallow"))
        // {
        //     // Debug.Log("exited Marshmallow");
        // }
        if (collision.gameObject.CompareTag("Ground")) //normal
        {
            _isAlive = true;
            _isSpeedBoosted = false;
            _isSpeedSlowed = false;

            // Debug.Log("exited ground");
        }
    }

}
