using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Joystick Joystick;
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

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {

        var movement = Input.GetAxis("Horizontal");
        if (_isAlive)
        {
            //KEYBOARD
            if (_isSpeedBoosted)
            {
                _rigidbody.velocity = new Vector2(movement * MovementSpeed * SpeedMultiplier, _rigidbody.velocity.y);


                if(Joystick.joystickVec.x != 0)
                _rigidbody.velocity = new Vector2(Joystick.joystickVec.x * MovementSpeed * SpeedMultiplier, _rigidbody.velocity.y);
            }
            else if (_isSpeedSlowed)
            {
                _rigidbody.velocity = new Vector2(movement * MovementSpeed / SpeedDivider, _rigidbody.velocity.y);


                if(Joystick.joystickVec.x != 0)
                _rigidbody.velocity = new Vector2(Joystick.joystickVec.x * MovementSpeed / SpeedDivider,  _rigidbody.velocity.y);
            }
            else
            {
                _rigidbody.velocity = new Vector2(movement * MovementSpeed, _rigidbody.velocity.y);


                if(Joystick.joystickVec.x != 0)
                _rigidbody.velocity = new Vector2(Joystick.joystickVec.x * MovementSpeed, _rigidbody.velocity.y);
            }

        }

        // if (Mathf.Approximately(0, movement))
        //     _rigidbody.transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        if(_timeToJumpEnterCollision > 0){
            _timeToJumpEnterCollision -= Time.deltaTime;
        }


        //jump
        if ((Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.01f) || (Input.GetButtonDown("Jump") && _timeToJumpEnterCollision > 0))
        {
            _timeToJumpEnterCollision = 0;
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            Debug.Log("jumper");
        }

        //jump cut jak chcesz to sobie odkomentuj 

        // if(Input.GetKey(KeyCode.Space) && _isJumping){
        //     if(_jumpTimeCounter > 0){
        //         _rigidbody.velocity = Vector2.up * JumpForce;
        //         _jumpTimeCounter -= Time.deltaTime;
        //     }
        //     else{
        //         _isJumping = false;
        //     }
        // }

        // if(Input.GetKeyUp(KeyCode.Space)){
        //     _isJumping = false;
        // }
    }

    public void JumpButton(){
        if ((Mathf.Abs(_rigidbody.velocity.y) < 0.01f) ||  (_timeToJumpEnterCollision > 0)){
            _timeToJumpEnterCollision = 0;
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            Debug.Log("jumper");
        }
        Debug.Log("jumper2");
    }


    //detect collision with other objects
    void OnCollisionEnter2D(Collision2D collision)
    {
        _timeToJumpEnterCollision = 0.5f;

        if (collision.gameObject.CompareTag("RedGround")) //ded
        {
            _isAlive = false;
            _isSpeedBoosted = false;
            _isSpeedSlowed = false;

            // _rigidbody.velocity = Vector3.zero;
            // _rigidbody.angularVelocity = 0f;

        }
        else if (collision.gameObject.CompareTag("Ground")) //normal
        {
            _isAlive = true;
            _isSpeedBoosted = false;
            _isSpeedSlowed = false;

            Debug.Log("entered ground");
        }
        else if (collision.gameObject.CompareTag("GreenGround")) //speed booster
        {
            _isAlive = true;
            _isSpeedBoosted = true;
            _isSpeedSlowed = false;

            Debug.Log("GreenGround");
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
        else if (collision.gameObject.CompareTag("Marshmallow"))
        {
            Debug.Log("entered Marshmallow");
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("Marshmallow"))
        {
            Debug.Log("exited Marshmallow");
        }
        else if (collision.gameObject.CompareTag("Ground")) //normal
        {
            _isAlive = true;
            _isSpeedBoosted = false;
            _isSpeedSlowed = false;

            Debug.Log("exited ground");
        }
    }

}
