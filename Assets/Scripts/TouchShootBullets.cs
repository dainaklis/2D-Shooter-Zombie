using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchShootBullets : MonoBehaviour
{
    [SerializeField] private GameObject bullets;
    [SerializeField] private Transform StartPosition;

    [SerializeField] private GameObject GunsPlayer;


    private Vector3 target;
    [SerializeField] private GameObject crosshairs;


    [SerializeField] private float bulletSpeed = 10f;

    [SerializeField] private ParticleSystem ak47MuzzleFlash;

    void Start()
    {
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {

        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //float rotationZ = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);


        // target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - GunsPlayer.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        GunsPlayer.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);


        if (Input.GetMouseButtonDown(0))
        {
            // float distance = difference.magnitude;
            // Vector2 direction = difference/distance;
            // direction.Normalize();

            //fireBullet(direction,rotationZ);

            fireBulletBeDirection();

            ak47MuzzleFlash.Play();
            SoundControl.sound.PlaySoundAK47();


        }

        // void fireBullet(Vector2 direction, float rotationZ)
        // {
        //     GameObject spawnBullet = Instantiate(bullets) as GameObject;
        //     spawnBullet.transform.position = StartPosition.position;
        //     spawnBullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ  - 90f);
        //     spawnBullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        //     AmmoText.ammoText.defenseAmmoAmount -= 1;
        // }

        void fireBulletBeDirection()
        {
            GameObject spawnBullet = Instantiate(bullets) as GameObject;
            spawnBullet.transform.position = StartPosition.position;
            spawnBullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ  - 90f);
            spawnBullet.GetComponent<Rigidbody2D>().velocity = StartPosition.up * bulletSpeed;

            DefenseAmmoText.ammoText.ammoAmount -= 1;

            // GameObject spawnBullet = Instantiate(bullets, StartPosition.position, Quaternion.identity);
            // spawnBullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
        

    }
}
