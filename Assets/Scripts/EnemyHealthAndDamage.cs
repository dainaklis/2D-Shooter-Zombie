using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthAndDamage : MonoBehaviour
{
    static public EnemyHealthAndDamage enemyHealthAndDamage;
    public int enemyMaxHealth;
    public int currentEnemyHealth;


    [SerializeField] private GameObject hitEffects;


    void Awake()
    {
        enemyHealthAndDamage = this;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // jei atsitrenkia kulka, spalvotas effects.
        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(hitEffects, transform.position, Quaternion.identity);
        }
    }

}
