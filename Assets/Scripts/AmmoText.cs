using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{   
    public static AmmoText ammoText;
    private Text text;
    public int ammoAmount = 20;


    void Awake()
    {
        ammoText = this;
    }


    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ammoAmount > 0 )
        {
            text.text = "Ammo: " + ammoAmount + " / 20"; 
              
        }
        else
        {
            text.text = "Nera Ammo !";

        }
    }
}
