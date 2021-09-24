using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensePlayer : MonoBehaviour
{   

    [SerializeField] private Transform explotion;
    [SerializeField] private GameObject gameOverObject;
    [SerializeField] private GameObject hitEffects;
    [SerializeField] private GameObject gunsDisable;

    //--------------------------------------------------------
    
    [SerializeField] private GameObject floatTextDamage;
    //---------------------------------------------------------------------------------------------------------------
    [Header ("HEALTH BAR")]

    public int maxHealth = 100;
    public int currentHealth;

    public  DefenseHealhtBar instHealtBar;
    // --------------------------------------------------------------------

    void Awake()
    {
        currentHealth = maxHealth;

        instHealtBar.SetMaxHealth(maxHealth);

        Time.timeScale = 1;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);

            int damage = Random.Range(15, 25);
            TakeDamage(damage);

            if (currentHealth <= 0)
            {
                StartCoroutine(ExplotionDefensePlayer()); 
                print("LOSE  COLLISION !!!");
                
            }


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);

            int damage = Random.Range(15, 25);
            TakeDamage(damage);

            if (currentHealth <= 0)
            {
                StartCoroutine(ExplotionDefensePlayer()); 
                print("LOSE  TRIGGER !!!");
                
            }
        }
    }


    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        PopUpText(damage);

        SoundControl.sound.PlaySoundEnemyHit();
        Instantiate(hitEffects, transform.position, Quaternion.identity);
        instHealtBar.SetHealth(currentHealth);
    }

    IEnumerator ExplotionDefensePlayer()
    {
        Destroy(gameObject);

        Instantiate(explotion, transform.position, Quaternion.identity);

        SoundControl.sound.PlaySoundgameOver();
        gameOverObject.SetActive(true); 
        gunsDisable.SetActive(false);

        yield return new WaitForSeconds(1f); 
       
    }

    private void PopUpText(int damage)
    {
        float posX = Random.Range (-6.7f, -4.9f);
        float posY = Random.Range (-0.3f, 0.3f);

        GameObject textDamage =  Instantiate(floatTextDamage, new Vector2(posX, posY), Quaternion.identity) as GameObject;

        //---text paraso DAMAGE ir RANDOM COLOR ------------------------
        textDamage.GetComponentInChildren<TextMesh>().text = "- " + damage.ToString();
        textDamage.GetComponentInChildren<TextMesh>().color = new Color(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2), 1f);
    }

}
