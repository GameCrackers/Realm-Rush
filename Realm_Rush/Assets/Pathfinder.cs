using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;

    [SerializeField] Waypoint startPoint, endPoint;
    Vector2Int[] directions = { 
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
  
    };

  
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();

        ColorStartEndBlock();


        Pathfind();
    }

    private void Pathfind()
    {
        queue.Enqueue(startPoint);

        while(queue.Count >= 0 && isRunning == true)
        {
            var searchCenter = queue.Dequeue();

            StopWhenEndPointFound(searchCenter);

        
            ExploreNeighbours(searchCenter,queue);

            searchCenter.isExplored = true;

        }
    }

    private void StopWhenEndPointFound(Waypoint searchCenter)
    {
        if(endPoint == searchCenter)
        {
            isRunning = false;
            print("Found End Point" + searchCenter);
        }
    }

    private void ExploreNeighbours(Waypoint searchCenter,Queue<Waypoint> queue)
    {
        if (isRunning)
        {
            print("Searching from center: " + searchCenter);

            foreach (Vector2Int dir in directions)
            {


                Vector2Int explorationCoord = searchCenter.GetPosition() + dir;

                QueueNewNeighbor(queue, explorationCoord);
            }

        }
        else
        {
            return;
        }
        /*  try
          {
              grid[explorationCoord].SetTopColor(Color.blue);
          }
          catch
          {

          }*/
    }

    private void QueueNewNeighbor(Queue<Waypoint> queue, Vector2Int explorationCoord)
    {
        if (grid.ContainsKey(explorationCoord))
        {
            Waypoint neighbor = grid[explorationCoord];

            if (!neighbor.isExplored)
            {
                neighbor.SetTopColor(Color.blue);

                queue.Enqueue(neighbor);

                print("Queueing " + neighbor);

            }
        }
        else
        {
            return;
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
