using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    private GridUpdate gu;
    private List<Vector3> obstacleCoords = new List<Vector3>();
    [SerializeField] GameObject obsm;
    private int[,] gridMap;

    private void Start()
    {
        gridMap = new int[10, 10] { 
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } };

        gu = obsm.GetComponent<GridUpdate>();
    }
    public void updateGrid()
    {
        obstacleCoords = gu.gridUpdate();
        foreach(Vector3 v in obstacleCoords)
        {
            gridMap[(int)v.x, (int)v.z] = 0;
            Debug.Log(v.x + " " + v.z);
        }
    }
}
