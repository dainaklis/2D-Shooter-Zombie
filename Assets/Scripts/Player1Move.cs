using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private float jumpForce;
    private float movementX;
    private Vector3 localScale;

    private Rigidbody2D playerRb;
    private Animator playerAnim;
    private SpriteRenderer playerSp;

    private string RUN_ANIMATION = "Run";
    private string GROUND_TAG = "Ground";
    private bool isGrounded;




    // ---------------------------------------------------------------------------------------------------------
    
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();

        playerSp = GetComponent<SpriteRenderer>();

        localScale = transform.localScale;

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatedPlayer();
        PlayerJump();
        
    }

    private void FixedUpdate()
    {
        //PlayerJump();

    }



    // ----------------------------------- CLASS -------------------------------------------------------------------------------
    private void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * moveSpeed * Time.deltaTime; 
    }

    private void AnimatedPlayer()
    {
        if (movementX > 0)
        {
            playerAnim.SetBool(RUN_ANIMATION, true);
            //playerSp.flipX = false;
            transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
        }
        else if (movementX < 0)
        {
            playerAnim.SetBool(RUN_ANIMATION, true);
            //playerSp.flipX = true;
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        }
        else
        {
            playerAnim.SetBool(RUN_ANIMATION, false);
        }
    }


    public void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;

            playerRb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}
