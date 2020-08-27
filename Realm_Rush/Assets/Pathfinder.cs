using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint startPoint, endPoint;
    Vector2Int[] directions = { 
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right
  
    };
  
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();

        ColorStartEndBlock();

        ExploreNeighbours();
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int dir in directions)
        {
            Vector2Int explorationCoord = startPoint.GetPosition() + dir;

            /* if (grid.ContainsKey(explorationCoord))
             {
                 grid[explorationCoord].SetTopColor(Color.blue);
             }*/

            try
            {
                grid[explorationCoord].SetTopColor(Color.blue);
            }
            catch
            {

            }

        }
    }

    private void ColorStartEndBlock()
    {
        startPoint.SetTopColor(Color.black);
        endPoint.SetTopColor(Color.yellow);
    }

    private void LoadBlocks()
    {
        Waypoint[] wayPointList = FindObjectsOfType<Waypoint>();

        foreach (Waypoint waypoint in wayPointList)
        {
            Vector2Int gridPos = waypoint.GetPosition();

            //Check for overlappin blocks
            bool isOverlapping = grid.ContainsKey(gridPos);

            if (isOverlapping)
            {
                Debug.LogWarning("Found Overlappin Block:" + waypoint);
            } 
            else
            {
                grid.Add(gridPos,waypoint);
            }

            print("Loaded " + grid.Count + " Blocks!");

        }

    }

   
}
