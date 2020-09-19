using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{

    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    Queue<Tower> towerQueue = new Queue<Tower>();
    //Queue<Waypoint> towerPosQueue = new Queue<Waypoint>();
   

    public void AddTowerToBlock(Waypoint blockClicked)
    {
         if(towerQueue.Count < towerLimit)
        {
            Tower addedTower = Instantiate(towerPrefab, blockClicked.transform.position, Quaternion.identity);

            addedTower.SetBaseWaypoint(blockClicked);


            towerQueue.Enqueue(addedTower);


        }
        else
        {
            Tower dequeuedTower = towerQueue.Dequeue();
         
            dequeuedTower.GetBaseWaypoint().isPlaceable = true;

            
            dequeuedTower.transform.position = blockClicked.transform.position;

            dequeuedTower.SetBaseWaypoint(blockClicked);

           
            towerQueue.Enqueue(dequeuedTower);

        }

        blockClicked.isPlaceable = false;

    }


}
