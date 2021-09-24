using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBullets : MonoBehaviour
{
    static public DefenseBullets bulletDestroy;
    [SerializeField] private GameObject bloodEffects;

  

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

            SoundControl.sound.PlaySoundEnemyHit();

            Instantiate(bloodEffects, transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(gameObject);

    
            DefenseScoreText.scoreText.killAmountDefense ++;

            if (DefenseScoreText.scoreText.highKillAmountDefense < DefenseScoreText.scoreText.killAmountDefense)
            {
                PlayerPrefs.SetInt("highKillAmountDefense", DefenseScoreText.scoreText.killAmountDefense);
            }

        }

        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }


    }

}
