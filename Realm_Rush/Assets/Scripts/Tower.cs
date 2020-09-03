using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToMove;
    [SerializeField] Transform targetToLookAt;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        objectToMove.LookAt(targetToLookAt);
    }
}
