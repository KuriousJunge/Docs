using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    
    TextMesh textMesh;
    Waypoint waypoint;

   
    private void Awake() {
        textMesh = GetComponentInChildren<TextMesh>();
        waypoint = GetComponent<Waypoint>();
        
    }

    void Update() {
        SnaptoGrid();
       // UpdateLabel();

    }
    private void SnaptoGrid() {
        int gridSize = waypoint.GetGridSize();
        //waypoint.GetGridPos(); 
        transform.position = new Vector3(waypoint.GetGridPos().x * gridSize,
                                         0f,
                                         waypoint.GetGridPos().y*gridSize);
    }

    private void UpdateLabel() {
        Vector2 gridPos = waypoint.GetGridPos();
        
        string LabelText = gridPos.x  + "," + gridPos.y ;
        textMesh.text = LabelText;
        gameObject.name = LabelText;
    }

  
}
