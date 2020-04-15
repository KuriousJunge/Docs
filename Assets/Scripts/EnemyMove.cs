using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Pathfinder pathfinder;


    private void Start() {

        pathfinder = GameObject.Find("World").GetComponent<Pathfinder>();
        
         List<Waypoint> path = pathfinder.GetPath();
        
        StartCoroutine(FollowPath(path));
    }
 
    IEnumerator FollowPath(List<Waypoint> path) { 
        foreach (Waypoint waypoint in path) {

            transform.position = waypoint.transform.position;
            
            yield return new WaitForSeconds(1f);
                       
        }
        Debug.Log("Looping finished");
    }

    
}
