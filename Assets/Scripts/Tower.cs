using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // parameters of each tower
    [SerializeField] Transform objectToPan;
    
    [SerializeField] float distanceToEnemy;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;

    //state
    [SerializeField]Transform targetEnemy;


    void Update() {

        SetTargetEnemy();
        if (targetEnemy != null) {            
            FireAtEnemy();
            objectToPan.LookAt(targetEnemy.localPosition + new Vector3(0f,3f,0f));
        }
        else {
            Shoot(false);
        }                 
    }

    private void SetTargetEnemy() {

         var sceneEnimies = FindObjectsOfType<EnemyDammage>();
         if (sceneEnimies.Length == 0) return;

        Transform closestEnemy = sceneEnimies[0].transform;
        foreach(EnemyDammage testEnemy in sceneEnimies) {
            closestEnemy = GetClosestEnemy(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform transformA, Transform transformB) {
        
        var distanceToA = Vector3.Distance(objectToPan.transform.position, transformA.transform.position);
        var distanceToB = Vector3.Distance(objectToPan.transform.position, transformB.transform.position);

        if (distanceToA < distanceToB) return transformA;
        else return transformB;
    }

    private void FireAtEnemy() {
        distanceToEnemy = Vector3.Distance(objectToPan.transform.position, targetEnemy.transform.position);
        if (Mathf.Abs(distanceToEnemy) < attackRange) {
            Debug.Log("enemy in  range");

            Shoot(true);
        }
        else Shoot(false);
    }

    private void Shoot(bool isActive) {

        var emission = projectileParticle.emission;
        emission.enabled = isActive;
        
    }
}
