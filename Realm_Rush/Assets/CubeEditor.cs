using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[SelectionBase] //Select Entire Cube When Clicked
public class CubeEditor : MonoBehaviour
{
  
    [SerializeField] [Range(1f, 20f)] float gridSize = 10f;
    // Update is called once per frame
    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        snapPos.y = 0f;

        transform.position = snapPos;

        TextMesh textMesh = GetComponentInChildren<TextMesh>();

        string coord = "(" + (snapPos.x / gridSize).ToString() + "," + (snapPos.z / gridSize).ToString() + ")";

        textMesh.text = coord;
        gameObject.name = coord;
    }
}
