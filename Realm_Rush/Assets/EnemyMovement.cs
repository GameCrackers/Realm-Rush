using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> pathList;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
        /*print("Unity is taking Control!!!!!");*/
    }

    IEnumerator FollowPath()
    {
    /*    print("Start Patrol!");*/
        foreach (Waypoint waypoint in pathList)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
   /*         print("Visiting Block" + waypoint.name + "!");*/
        }

 /*       print("End Patrol!");*/
    }

    // Update is called once per frame
  
}
