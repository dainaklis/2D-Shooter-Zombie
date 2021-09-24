using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyDefense : MonoBehaviour
{
    [SerializeField] private GameObject [] monsterReference;

    [SerializeField] private Transform leftPos, rightPos;
    //[SerializeField] private int spawnSpeed;

    private GameObject spawnedMonster;
    private int randomIndex;
    private int randomSide;



    // ------------------------------------------------------------------------------------
    void Start()
    {
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
            //spawnSpeed = Random.Range(1, 5);
            
            yield return new WaitForSeconds(Random.Range(1, 5));

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
