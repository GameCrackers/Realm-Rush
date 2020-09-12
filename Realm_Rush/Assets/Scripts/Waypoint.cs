using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false; //to avoid duplicated exploration in BFS search

    [SerializeField] public Waypoint exploredFrom; // to store the path that leads to endpoint
    [SerializeField] public bool isPlaceable = true;

    const int gridSize = 10;
    //Vector2Int gridPos;
    // Start is called before the first frame update
    void Start()
    {

    }
    public int GetGridSize()
    {
        return gridSize;
    }


    public Vector2Int GetPosition()
    {
        return new Vector2Int(
                    Mathf.RoundToInt(transform.position.x / gridSize),
                    Mathf.RoundToInt(transform.position.z / gridSize)
            );
    }


   
    public void SetTopColor(Color color)
    {
        //Find Child Object thru transform.Find(name)
        MeshRenderer TopMesh = transform.Find("Quad (2)").GetComponent<MeshRenderer>();
        TopMesh.material.color = color;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
