using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxFonas : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private float relativeMove;
    //[SerializeField] private bool lockY = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // if (lockY)
        // {
        //     transform.position = new Vector2(cam.position.x * relativeMove, cam.position.y);
        // }
        // else
        // {
        //     transform.position = new Vector2(cam.position.x * relativeMove, cam.position.y * relativeMove);
        // }

        transform.position = new Vector2(cam.position.x * relativeMove, cam.position.y * relativeMove);
    }

}
