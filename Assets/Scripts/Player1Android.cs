using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Android : MonoBehaviour
{

    // ------------------------- ANDROID ---------------------------
    static public Player1Android player1Android;
    // ----------------- JUDEJIMAS ZOTOV -------------------
    private float horizontalMove;
    [SerializeField] private float speedMove;
    private bool moveLeft;
    private bool moveRight;
    private Rigidbody2D playerRb;
    private Animator playerAnim;

    private Vector3 localScale;

    [SerializeField] private Transform explotion;
    [SerializeField] private GameObject hitEnemy;
    

    //--------------------------------------Jump and (GroundCheck(is Antarsoft))------------------------------------
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded = false;
    private bool canUp;

    private string RUN_ANIMATION = "Run";

    // ---------------------------------------------------------------------------------------------------------

    [SerializeField] private GameObject gameOver;
    [SerializeField] private Text gameOverText;

    //---------------------------------------------------------------------------------------------------------------
    [Header ("HEALTH BAR")]

    public int maxHealth = 20;
    public int currentHealth;

    public  HealttBar instHealtBar;



    //---------------------------------------------------------------------------------------------------------------
    
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();

        localScale = transform.localScale;
        Time.timeScale = 1;

        player1Android = this;

    

    }

    void Start()
    {
        // -------------------------------------------
        moveLeft = false;
        moveRight = false;
        canUp = false;

        // -------------------------------------------

        gameOver.SetActive(false);

        currentHealth = maxHealth;

        instHealtBar.SetMaxHealth(maxHealth);


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

            TakeDamage(2);

            if (currentHealth == 0)
            {
                StartCoroutine(ExplotionPlayer());
            }

        }


    }


    //----- VAIDUOKLIS sunaikina ir muzika------------------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(2);

            if (currentHealth == 0)
            {
                StartCoroutine(ExplotionPlayer());
            }

            
            

        }
    }

    // ---------------------------------------------------------------------------------------------------------------------------

    IEnumerator ExplotionPlayer()
    {
        //CameraShake.cameraShake.CameraShaking();

        Destroy(gameObject);

        SoundControl.sound.PlaySoundgameOver();

        Instantiate(explotion, transform.position, Quaternion.identity);

        gameOver.SetActive(true);

        gameOverText.text = "You Kill: " + ScoreText.scoreText.killAmount;

        yield return new WaitForSeconds(2f); 


    }

    //----------------------------------------------------------------

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        SoundControl.sound.PlaySoundPlayerhit();

        Instantiate(hitEnemy, transform.position, Quaternion.identity);

        instHealtBar.SetHealth(currentHealth);
    }

    public void CaroutineEplotionPlayer()
    {
        StartCoroutine(ExplotionPlayer());
        
    }
}
