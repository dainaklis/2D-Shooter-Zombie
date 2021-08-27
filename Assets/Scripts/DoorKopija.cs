using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKopija : MonoBehaviour
{
    public static DoorKopija doorKopija;

    [SerializeField] private GameObject door1;



    private void Awake()
    {
        doorKopija = this;
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
            
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);         

            

            //Destroy(gameObject);

            door1.SetActive(true);
        }
        
        
    }
}
