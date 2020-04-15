using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter; // the current searchCenter
    List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions =
        new Vector2Int[] { Vector2Int.up,// index 0
                           Vector2Int.right,
                           Vector2Int.down,
                           Vector2Int.left};

    
    public List<Waypoint> GetPath() {
        if (path.Count ==0) { //if there  is path  do we dont need to calculate it again , for purpose for ading multiple enemy
            CalculatePath();
        }

        return path;
    }

    private void CalculatePath() {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFistSearch();
        CreatePath();
    }

    void CreatePath() {
        
        SetAsPath(endWaypoint);
        Waypoint previous = endWaypoint.exeploredFrom;

        while (previous != startWaypoint) {
            SetAsPath(previous);
            previous = previous.exeploredFrom;
        }
      
        SetAsPath(startWaypoint);
        path.Reverse();

    }

    private void SetAsPath(Waypoint waypoint) {
        path.Add(waypoint);
        waypoint.isPlaceable = false;
    }

    

    void LoadBlocks() {

        Waypoint[] waypoints = GetComponentsInChildren<Waypoint>();
        foreach( var waypoint in waypoints) {

            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());

            if (!isOverlapping) {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }     
            else 
              Debug.Log("Skipping OverLapping Block " + waypoint);                     
        }
      //  Debug.Log(grid.Count);
    }

    void ColorStartAndEnd() {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    void BreadthFistSearch() {

        queue.Enqueue(startWaypoint);// add to the  Queue

        while (queue.Count > 0 && isRunning) {
           // Debug.LogWarning(queue.Count);
            searchCenter = queue.Dequeue(); // searchCenter  = startWaypoint  & remove the first element from the Queue
           // Debug.Log(" Search from : " + searchCenter);
            HaltIfEndFound();

            ExploreNeighbour();
            searchCenter.isExplored = true;
        }

        Debug.Log("finish pathfinding ?");
        //Debug.LogWarning(queue.Count);
    }
    void HaltIfEndFound() {

        if (searchCenter == endWaypoint) 
            isRunning = false;
    }

    void ExploreNeighbour() {
        if (!isRunning) return;

        foreach (var direc in directions) {
            Vector2Int neighbourCourdinate = searchCenter.GetGridPos() + direc;
            if (grid.ContainsKey(neighbourCourdinate)) {// check if there is this new  block direction in dictinary 
                QueueNewNeighbours(neighbourCourdinate);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCourdinate) {
        if(grid[neighbourCourdinate].isExplored || queue.Contains(grid[neighbourCourdinate])) {
            // noting
        }
        else {           
            queue.Enqueue(grid[neighbourCourdinate]);  // add the element from the dictionary to the Queue
            grid[neighbourCourdinate].exeploredFrom = searchCenter;
            
        }        
    }

    
    
}
