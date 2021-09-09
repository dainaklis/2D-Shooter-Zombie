using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{

    static public BulletDestroy bulletDestroy;
    [SerializeField] private GameObject bloodEffects;

    [SerializeField] private GameObject hitEffects;

    //[SerializeField] private GameObject NewExplotionEffects;

    public int damage;


    void Awake()
    {
        bulletDestroy = this;
    }

    void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyMove>() != null)
        {
            //TakeDamage(1);

            SoundControl.sound.PlaySoundEnemyHit();

            //Instantiate(hitEffects, transform.position, Quaternion.identity);

            Instantiate(bloodEffects, transform.position, Quaternion.identity);
            //Instantiate(NewExplotionEffects, transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(gameObject);

    
            ScoreText.scoreText.killAmount ++;

            if (ScoreText.scoreText.highKillAmount < ScoreText.scoreText.killAmount)
            {
                PlayerPrefs.SetInt("highKillAmount", ScoreText.scoreText.killAmount);
            }

        }

        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }

        // if (collision.gameObject.tag == "Enemy")
        // {   

        //     SoundControl.sound.PlaySoundEnemyHit();

        //     Instantiate(bloodEffects, transform.position, Quaternion.identity);

        //     Destroy(gameObject);
        //     Destroy(collision.gameObject);
            
        // }


    }

    private void TakeDamage(int damage)
    {
        EnemyHealthAndDamage.enemyHealthAndDamage.currentEnemyHealth -= damage;

        print(EnemyHealthAndDamage.enemyHealthAndDamage.currentEnemyHealth);

    }

    
}
