using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    private Transform player;
    private Vector3 temPos;

    [SerializeField] private float minX, maxX;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void LateUpdate()
    {   
        if (player == null)
        {
            return;
        }

        
        temPos = transform.position;
        temPos.x = player.position.x;

        if (temPos.x < minX)
        {
            temPos.x = minX;
        }

        if (temPos.x > maxX)
        {
            temPos.x = maxX;
        }

        transform.position = temPos;
    }
}
