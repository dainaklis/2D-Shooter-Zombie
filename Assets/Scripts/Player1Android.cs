using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Android : MonoBehaviour
{

    // ------------------------- ANDROID ---------------------------

    // ----------------- JUDEJIMAS ZOTOV -------------------
    private float horizontalMove;
    [SerializeField] private float speedMove;
    private bool moveLeft;
    private bool moveRight;
    private Rigidbody2D playerRb;
    private Animator playerAnim;

    private Vector3 localScale;

    [SerializeField] private Transform explotion;
    

    //--------------------------------------Jump and (GroundCheck(is Antarsoft))------------------------------------
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded = false;
    private bool canUp;

    private string RUN_ANIMATION = "Run";

    // ---------------------------------------------------------------------------------------------------------

    [SerializeField] private GameObject gameOver;
    [SerializeField] private Text gameOverText;




    //---------------------------------------------------------------------------------------------------------------
    
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();

        localScale = transform.localScale;
        Time.timeScale = 1;

    

    }

    void Start()
    {
        // -------------------------------------------
        moveLeft = false;
        moveRight = false;
        canUp = false;

        // -------------------------------------------

        gameOver.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
    // ------------------ANDROID-----------------------------

        if (canUp)
        {
            
            if (isGrounded)
            {
                SoundControl.sound.PlaySoundsoundJump();

                isGrounded = false;
                playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            }
            
        }

    // --------------------------------------------------------------------
        
    }

    private void FixedUpdate()
    {
        playerRb.velocity = new Vector2(horizontalMove, playerRb.velocity.y);

        Movement();

    }

    // ----------------ANDROID-------------------------------------------------
    public void PointerDownLeft()
    {
        moveLeft = true;
    }
    public void PointerUpLeft()
    {
        moveLeft = false; 
    }

    public void PointerDownRight()
    {
        moveRight = true;
    }
    public void PointerUpRight()
    {
       moveRight = false; 
    }

    public void PointerDownUp()
    {
        canUp = true;
    }
    public void PointerUpUp()
    {
        canUp = false;
    }




    private void Movement()
    {
        if (moveLeft)
        {
            horizontalMove = -speedMove;

            playerAnim.SetBool(RUN_ANIMATION, true);
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);

        
        }

        else if (moveRight)
        {
            
            horizontalMove = speedMove;

            playerAnim.SetBool(RUN_ANIMATION, true);
            transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);

            
        }
        else
        {
            horizontalMove = 0;
    
            playerAnim.SetBool(RUN_ANIMATION, false);

            

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag =="Enemy")
        {


            StartCoroutine(ExplotionPlayer());

        }


    }


    //----- VAIDUOKLIS sunaikina ir muzika------------------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy(gameObject);

            // SoundControl.sound.PlaySoundgameOver();

            // Instantiate(explotion, transform.position, Quaternion.identity);

            StartCoroutine(ExplotionPlayer());
            

        }
    }

    // ---------------------------------------------------------------------------------------------------------------------------

    IEnumerator ExplotionPlayer()
    {
        Destroy(gameObject);

        SoundControl.sound.PlaySoundgameOver();

        Instantiate(explotion, transform.position, Quaternion.identity);

        gameOver.SetActive(true);

        gameOverText.text = "You Kill: " + ScoreText.scoreText.killAmount;

        yield return new WaitForSeconds(2f); 


    }

    //----------------------------------------------------------------
}
