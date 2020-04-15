using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] EnemyDammage enemyPrefab;
    [Range(.2f, 20f)] [SerializeField] float _secondBetweenSpawn = 2f;

   // static public List<EnemyDammage> spawningList = new List<EnemyDammage>();

    void Start()
    {
        StartCoroutine(SpawnEnemiesRoutine());
    }

    

    void Update()
    {
        
    }

    IEnumerator SpawnEnemiesRoutine() {
        while (true) {
            EnemyDammage newEnemy = Instantiate(enemyPrefab,transform.position,Quaternion.identity) as EnemyDammage;

            yield return new WaitForSeconds(_secondBetweenSpawn);
            
            if(newEnemy !=null)
                newEnemy.transform.parent = this.transform;
          //  spawningList.Add(newEnemy);
          //  Debug.Log("List Count : " +spawningList.Count);


        }
    }
}
