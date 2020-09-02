using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[SelectionBase] //Select Entire Cube When Clicked
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;
    //   Vector3 gridPos;

    //[SerializeField] [Range(1f, 20f)] float gridSize = 10f;
    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    // Update is called once per frame
    void Update()
    {

        int gridSize = waypoint.GetGridSize();

        Vector3 gridPos = new Vector3(
            waypoint.GetPosition().x,
            0f,
            waypoint.GetPosition().y
            );

        SnapToPosition(gridSize, gridPos);

        UpdateLabel(gridSize, gridPos);
    }

    private void UpdateLabel(int gridSize, Vector3 gridPos)
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();

        string coord = 
            "(" + (gridPos.x).ToString() + 
            "," + 
            (gridPos.z).ToString() + ")";

        textMesh.text = coord;
        gameObject.name = coord;
    }

    private void SnapToPosition(int gridSize, Vector3 gridPos)
    {


        transform.position = gridPos * gridSize;
    }
}
