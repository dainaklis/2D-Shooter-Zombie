using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinExplotions : MonoBehaviour
{
    [SerializeField] private GameObject winExplotions;
    private GameObject spawnedFejervers;

    [SerializeField] private float time;
    [SerializeField] private float rate;
    void Start()
    {
        StartCoroutine(SpawnWinEffects2());
        //InvokeRepeating("SpawnWinEffects", time, rate);

    }

    // Update is called once per frame
    void Update()
    {
        //Instantiate(winExplotions, transform.position, Quaternion.identity);

        //InvokeRepeating("SpawnWinEffects", time, rate);
        //StartCoroutine(SpawnWinEffects2());
 
    }


    private void SpawnWinEffects()
    {
        Vector3 fejerversSpawnPosition = new Vector3(Random.Range(-10f, 10f),Random.Range(-4f, 4f), 0f);

        Instantiate(winExplotions,fejerversSpawnPosition, Quaternion.identity); 
    }


    IEnumerator SpawnWinEffects2()
    {   
        

        while (true)
        {
            
            Vector3 fejerversSpawnPosition = new Vector3(Random.Range(-10f, 10f),Random.Range(-4f, 4f), 0f);

            Instantiate(winExplotions,fejerversSpawnPosition, Quaternion.identity); 

            yield return new WaitForSeconds(time);

            fejerversSpawnPosition = new Vector3(Random.Range(-10f, 10f),Random.Range(-4f, 4f), 0f);

            Instantiate(winExplotions,fejerversSpawnPosition, Quaternion.identity); 
        }


    }
}
