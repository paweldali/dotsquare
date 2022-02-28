using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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

    private bool _isJumping = false;



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

        //XD


        }

        // if (Mathf.Approximately(0, movement))
        //     _rigidbody.transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;


      

        //jump
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.01f)
        {
            _isJumping = true;
            // _jumpTimeCounter = JumpTime;
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
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


    //detect collision with other objects
    void OnCollisionEnter2D(Collision2D collision)
    {

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
        }
        else if (collision.gameObject.CompareTag("GreenGround")) //speed booster
        {
            _isAlive = true;
            _isSpeedBoosted = true;
            _isSpeedSlowed = false;

            Debug.Log("GreenGround");
        }
        else if (collision.gameObject.CompareTag("OrangeGround"))
        { //trampoline
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
    }

}
