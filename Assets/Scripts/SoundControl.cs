using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public static SoundControl sound;
    private AudioSource audioSrc;
    [SerializeField] private AudioClip soundPistol, soundShotgun, soundAK, soundJump, soundWalk, soundGameOver, outAmmo, soundEnemyHit, soundNextGuns, soundPlayerHit, soundReload, soundFireWorks, soundStep;


    private void Awake() 
    {
        if (sound == null)
        {
           sound = this; 
        } 

    }
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    public void PlaySoundReload()
    {
        audioSrc.PlayOneShot(soundReload);
    
    }

    public void PlaySoundNextGuns()
    {
        audioSrc.PlayOneShot(soundNextGuns);
    
    }

    public void PlaySoundPlayerhit()
    {
        audioSrc.PlayOneShot(soundPlayerHit);
    
    }
    public void PlaySoundPistol()
    {
        audioSrc.PlayOneShot(soundPistol);
    
    }

    public void PlaySoundShotgunl()
    {
        audioSrc.PlayOneShot(soundShotgun);
    }

    public void PlaySoundAK47()
    {
        audioSrc.PlayOneShot(soundAK);
    }

    public void PlaySoundsoundJump()
    {
        audioSrc.PlayOneShot(soundJump);
        //StartCoroutine(PlayAndStop());
        
    }

    public void PlaySoundsoundWalk()
    {
        audioSrc.PlayOneShot(soundWalk);
    }

    public void PlaySoundgameOver()
    {
        audioSrc.PlayOneShot(soundGameOver);
    }

    public void PlaySoundStop()
    {
        audioSrc.Stop();
    }
    public void PlaySoundoutAmmo()
    {
        audioSrc.PlayOneShot(outAmmo);
        
        //AudioSource.PlayClipAtPoint(outAmmo, transform.position);
    }
    public void PlaySoundEnemyHit()
    {
        audioSrc.PlayOneShot(soundEnemyHit);
    }

    public void PlaySoundFireWorks()
    {
        audioSrc.PlayOneShot(soundFireWorks);
    }

    public void PlaySoundStepSounds()
    {
        audioSrc.PlayOneShot(soundStep);
    }

}
