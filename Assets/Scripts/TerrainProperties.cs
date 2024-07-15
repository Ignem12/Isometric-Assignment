using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TerrainProperties : MonoBehaviour
{
    [SerializeField] private string terrainType;
    private string obsName;
    private bool occupied;

    private void Update()
    {
        if(occupied == true && GameObject.Find(obsName) == false)
        {
            occupied = false;
        }
    }

    public string selectedTerrain()
    {
        return terrainType;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 7)
        {
            Debug.Log(collision.gameObject.name);
            obsName = collision.gameObject.name;
            occupied = true;
        }
    }

    public Vector3 coordinates()
    {
        return transform.position;
    }

    public bool isOccupied()
    {
        return occupied;
    }
}
