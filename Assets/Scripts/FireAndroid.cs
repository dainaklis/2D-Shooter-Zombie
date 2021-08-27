using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAndroid : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    //-------------------------------------------------------------------------------------------------------------


    public void PointerDownFire()
    {
        Fire.fire.canFire = true;
        //Fire.fire.PointerDownFire();

        if (Fire.fire.canFire && AmmoText.ammoText.ammoAmount == 0)
        {
        
            SoundControl.sound.PlaySoundoutAmmo();
        }
        
    }
    public void PointerUpFire()
    {
        Fire.fire.canFire = false;
        //Fire.fire.PointerUpFire();
    }

    //-------------------------------------------------------------------------------------------------------------

    public void ReloadAmmo()
    {
        AmmoText.ammoText.ammoAmount = 20;

        SoundControl.sound.PlaySoundReload();
    }

}   
