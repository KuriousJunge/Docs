using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDammage : MonoBehaviour
{
    [SerializeField] int hitPoints = 100;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other) {
        if (other.gameObject.name == "Bullet") {
            ProcessHit();
            
            if (hitPoints <= 0)
                KillEnemy();
        }
            
        

    }

    private void KillEnemy() {
       // EnemySpawner.spawningList.Remove(gameObject.GetComponent<EnemyDammage>()); // change the list to enemy damage

        Destroy(this.gameObject);

    }

    void ProcessHit() {
        hitPoints--;
        
    }
}
