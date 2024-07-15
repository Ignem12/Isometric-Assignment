using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUpdate : MonoBehaviour
{
    private List<Vector3> obstacleCoords;
    public List<Vector3> gridUpdate()
    {
        obstacleCoords= new List<Vector3>();
        foreach (Transform child in transform)
        {
            obstacleCoords.Add(child.transform.position);
        }

        return obstacleCoords;
    }
}
