using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScripts : MonoBehaviour
{
    public static DoorScripts doorScripts;


    private void Awake()
    {
        doorScripts = this;
    }
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);         

            //print("EINU i LVL - " + SceneManager.GetActiveScene().buildIndex + 1 + " !!!");

            Destroy(gameObject);

            gameObject.SetActive(false);
        }
        
        
    }
    
}
