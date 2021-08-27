using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{   
    public static WeaponControl weaponControl;
    private int wichWeaponSelected ;
    private GameObject weapon;
 
    // private bool canSwich = false;


    void Awake()
    {
        weaponControl = this;
    }
    
    void Start()
    {
        wichWeaponSelected = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // --------------------------------------------------------------------------------------------------------------------

    // public void PointerDownSwitch()
    // {
    //     canSwich = true;
    // }
    // public void PointerUpSwitch()
    // {
    //     canSwich = false; 
    // }


    //----------------------------------------------------------------------------------------------------

    public void SwitchWeapon()
    {
        SoundControl.sound.PlaySoundNextGuns();
        
        switch (wichWeaponSelected)
        {
            case 1:
                if (weapon != null)
                {
                    Destroy(weapon.gameObject);
                } 

                weapon = Instantiate(Resources.Load("Prefabs/Guns/Pistol_"), transform.position, transform.rotation) as GameObject;
                weapon.transform.SetParent(gameObject.transform);
                weapon.transform.localPosition = new Vector3(1.75f,-0.43f,0f);
                weapon.GetComponent<Renderer>().sortingOrder = gameObject.GetComponent<Renderer>().sortingOrder + 1;
                weapon.transform.localScale = new Vector3(-3f,3f,0f);
                wichWeaponSelected += 1;

                
                    
            break;

            case 2:
                if (weapon != null)
                {
                    Destroy(weapon.gameObject);
                }

                weapon = Instantiate(Resources.Load("Prefabs/Guns/AK47_"), transform.position, transform.rotation) as GameObject;
                weapon.transform.SetParent(gameObject.transform);
                weapon.transform.localPosition = new Vector3(2.25f,-0.6f,0f);
                weapon.GetComponent<Renderer>().sortingOrder = gameObject.GetComponent<Renderer>().sortingOrder + 1;
                weapon.transform.localScale = new Vector3(-3f,3f,0f);
                wichWeaponSelected += 1;

                
                    
            break;

            case 3:
                if (weapon != null)
                {
                    Destroy(weapon.gameObject);
                }

                weapon = Instantiate(Resources.Load("Prefabs/Guns/M3_"), transform.position, transform.rotation) as GameObject;
                weapon.transform.SetParent(gameObject.transform);
                weapon.transform.localPosition = new Vector3(1.69f,-0.47f,0f);
                weapon.GetComponent<Renderer>().sortingOrder = gameObject.GetComponent<Renderer>().sortingOrder + 1;
                weapon.transform.localScale = new Vector3(-3f,3f,0f);
                wichWeaponSelected += 1;

            
                
            break;

            case 4:
                if (weapon != null)
                {
                    Destroy(weapon.gameObject);
                }

                weapon = Instantiate(Resources.Load("Prefabs/Guns/Hand_"), transform.position, transform.rotation) as GameObject;
                weapon.transform.SetParent(gameObject.transform);
                weapon.transform.localPosition = new Vector3(1.43f,-0.23f,0f);
                weapon.GetComponent<Renderer>().sortingOrder = gameObject.GetComponent<Renderer>().sortingOrder + 1;
                weapon.transform.localScale = new Vector3(7f,7f,0f);
                wichWeaponSelected += 1;
                
            break;



        }


        if (wichWeaponSelected > 4)
        {
            wichWeaponSelected = 1;
        } 

     
    }
}
