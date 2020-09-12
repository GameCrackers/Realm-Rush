using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Tower towerPrefab;

 

    private void OnMouseOver()
    {
        //bool placeableFlag = FindObjectOfType<Waypoint>().isPlaceable;

        if (Input.GetMouseButtonDown(0) & gameObject.GetComponent<Waypoint>().isPlaceable == true)
        {
            //print("Block " + gameObject.name + " Clicked");
            Instantiate(towerPrefab, transform.position, Quaternion.identity);

            gameObject.GetComponent<Waypoint>().isPlaceable = false;

        }
    }
}
