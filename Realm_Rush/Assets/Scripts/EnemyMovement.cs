using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //[SerializeField] List<Waypoint> pathList;
    // Start is called before the first frame update

    void Start()
    {
        Pathfinder pathFinder = FindObjectOfType<Pathfinder>();
      
        print("Unity is taking Control!!!!!");
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Start Patrol!");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
            print("Visiting Block" + waypoint.name + "!");
        }

        print("End Patrol!");
    }

    // Update is called once per frame

}
