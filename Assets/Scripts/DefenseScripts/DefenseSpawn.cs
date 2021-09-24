using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseSpawn : MonoBehaviour
{
    [SerializeField] private GameObject [] monsterReference;

    [SerializeField] private Transform leftPos, rightPos;
    
    [SerializeField] private float speedSpawn;

    private GameObject spawnedMonster;
    private int randomIndex;
    private int randomSide;


    // ------------------------------------------------------------------------------------
    void Start()
    {
        //speedSpawn = Random.Range(1, 5);

        StartCoroutine(SpawnMonsters());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnMonsters()
    {
        while(true)
        {
            yield return new WaitForSeconds(speedSpawn);

            randomIndex = Random.Range(0, monsterReference.Length);

            randomSide = Random.Range(0, 2);
            //randomSide = 1;

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<EnemyMove>().speedMove = Random.Range(3, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);

            }
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<EnemyMove>().speedMove = -Random.Range(3, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }


    }
}
