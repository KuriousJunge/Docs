using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor; 
    const int gridSize = 10;

    public bool isExplored = false;
    public bool isPlaceable = true;

    public Waypoint exeploredFrom;


    private void Update() {
        //  set color blue;
       // if (isExplored == false) {
       //     SetTopColor(exploredColor); 
       // }

    }
    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(0))
              Debug.Log("mouse hover on " + gameObject.name);
    }

    public int GetGridSize() {
        return gridSize;
    }

    public Vector2Int GetGridPos() {

        return new Vector2Int(Mathf.RoundToInt(transform.position.x / gridSize) ,
                             
                             Mathf.RoundToInt(transform.position.z / gridSize) );
    }

    public void SetTopColor(Color color) {
        gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = color;
       // gameObject.transform.Find("Top").GetComponent<MeshRenderer>().material.color = color;
       
    }
}
