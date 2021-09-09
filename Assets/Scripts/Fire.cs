using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public static Fire fire;

    [Header("Bullets Atribudai")]  
    [SerializeField] private Rigidbody2D bullet;
    [SerializeField] private Rigidbody2D bulletLight;
    [SerializeField] private Transform barrel;
    private float bulletSpeed = 500f;

    [Header("Fire Rates")]  
    [SerializeField] public float fireRatePistol = 0.5f;

    [SerializeField] public float fireRateM3 = 1f;

    [SerializeField] public float fireRateAK47 = 0.2f;
    [SerializeField] public float fireRateHand = 0.2f;
    
    private float nextFire = 0f;

    public string currentWeaponName;

    public bool canFire;


    private string ATTACK_ANIMATION = "Hit";
    private Animator playerAnim;

    [Header("MuzzleEffects")] //----Naudota CG SMOOTHIE---- 
    [SerializeField] private ParticleSystem ak47MuzzleFlash;
    [SerializeField] private ParticleSystem pistolMuzzleFlash;
    [SerializeField] private ParticleSystem m3MuzzleFlash;


    //-----------------------------------------------------------------------------------------------

    void Awake()
    {
        fire = this;
    }

    void Start()
    {
        playerAnim = GameObject.FindWithTag("Player").GetComponent<Animator>();

        canFire = false;

        currentWeaponName = gameObject.name.Substring(0, name.IndexOf("_"));    
        
                  

    }

    void Update()
    {
        if (canFire && Time.time > nextFire && AmmoText.ammoText.ammoAmount > 0)
        {
            WeaponFire(currentWeaponName); 
        }

    }



    //-------------------------------------------------------------------------------------------------------------


    public void PointerDownFire()
    {
        canFire = true; 
        
    }
    public void PointerUpFire()
    {
        canFire = false; 
    }

    //-------------------------------------------------------------------------------------------------------------

    public void WeaponFire(string weaponName)
    {
               
        if (weaponName == "Pistol")
        {
            AmmoText.ammoText.ammoAmount -= 1;

            nextFire = Time.time + fireRatePistol;

            pistolMuzzleFlash.Play();
            


            var spawnBullet = Instantiate(bullet, barrel.position, barrel.rotation);
            spawnBullet.AddForce(barrel.up * bulletSpeed);

            SoundControl.sound.PlaySoundPistol();
            
        }

        else if (weaponName == "M3")
        {   
            AmmoText.ammoText.ammoAmount -= 3;

            nextFire = Time.time + fireRateM3;

            m3MuzzleFlash.Play();

            for (int i = 0; i <= 2; i++)
            {
                var spawnBullet = Instantiate(bullet, barrel.position, barrel.rotation);
                        
                switch (i)
                {
                    case 0:
                        spawnBullet.AddForce(barrel.up * bulletSpeed + new Vector3(0f, -90f, 0f));
                        break;

                    case 1:
                        spawnBullet.AddForce(barrel.up * bulletSpeed + new Vector3(0f, 0f, 0f));
                        break;

                    case 2:
                        spawnBullet.AddForce(barrel.up * bulletSpeed + new Vector3(0f, 90f, 0f));
                        break;
                } 

            }

            SoundControl.sound.PlaySoundShotgunl();
                
        }

        else if (weaponName == "AK47")
        {   
            AmmoText.ammoText.ammoAmount -= 1;

            nextFire = Time.time + fireRateAK47;

            ak47MuzzleFlash.Play();

            var spawnBullet = Instantiate(bulletLight, barrel.position, Quaternion.identity);
            spawnBullet.AddForce(barrel.up * bulletSpeed);

            SoundControl.sound.PlaySoundAK47();
                
        } 

        else if (weaponName == "Hand")
        {
            nextFire = Time.time + fireRateHand;

            playerAnim.SetBool(ATTACK_ANIMATION, true);

            SoundControl.sound.PlaySoundPlayerhit();

            StartCoroutine(AttackPlayer());
            
        


        
            IEnumerator AttackPlayer()
            {  
                    
                yield return new WaitForSeconds(0.2f);  
                playerAnim.SetBool(ATTACK_ANIMATION, false);     
                
         
            }   
    
        
        }

    }

    //----------------PIRSTINES SUNAIKINA ENEMY
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
             Destroy(collision.gameObject);
        }
    }



}






