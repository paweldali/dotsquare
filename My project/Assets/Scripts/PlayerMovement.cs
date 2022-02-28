using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    public float SpeedMultiplier = 2;
    private Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Mathf.Approximately(0, movement))
        transform.rotation = movement > 0 ? Quaternion.Euler(0,180,0) : Quaternion.identity;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        //detect collision with other objects
        void OnCollisionEnter2D(Collision2D collision)
        {
    
            if(collision.gameObject.CompareTag ("RedGround")
                {
                Debug.Log("RedGround");
                }
            if(collision.gameObject.CompareTag ("GreenGround")
                {
                Debug.Log("GreenGround");
                var movement = Input.GetAxis("Horizontal");
                transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed * SpeedMultiplier;
                }
        }    
    }
}
