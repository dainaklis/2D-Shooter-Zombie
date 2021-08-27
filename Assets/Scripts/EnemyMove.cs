using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [HideInInspector] public float speedMove;
    private Rigidbody2D enemyRb;



    // -----------------------------------------------------------------------------------------------------------

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        enemyRb.velocity = new Vector2(speedMove, enemyRb.velocity.y);
    }

}
