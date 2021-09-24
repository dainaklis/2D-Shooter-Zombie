using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseAmmoText : MonoBehaviour
{
    public static DefenseAmmoText ammoText;
    private Text text;
    public int ammoAmount;
    
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
            text.text = "Ammo: " + ammoAmount + " / 50"; 
              
        }
        else
        {
            text.text = "Nera Ammo !";

        }
    }
}
