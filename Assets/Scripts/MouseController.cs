using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    Camera cam;
    GameObject obj;
    private TerrainProperties terrainProperties;
    [SerializeField] TMP_Text blockType;
    [SerializeField] TMP_Text coords;
    [SerializeField] TMP_Text occupied;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject tileMarkerPrefab;
    private GameObject player;
    private Vector3 blockCoords;
    private GameObject tileMarker;
    private bool active = false;
    private void Start()
    {
        cam = Camera.main;
    }
    void FixedUpdate()
    {
        rayCastToggle();
        if(active)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;
            mousePos = cam.ScreenToWorldPoint(mousePos);
            Debug.DrawRay(transform.position, mousePos - transform.position, Color.yellow);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                obj = hit.transform.gameObject;
                terrainProperties = obj.GetComponent<TerrainProperties>();
                blockType.text = "Name: " + terrainProperties.selectedTerrain();
                coords.text = "Coordinates: " + terrainProperties.coordinates().x + ", " + terrainProperties.coordinates().z;
                occupied.text = "Occupied: " + terrainProperties.isOccupied();
                blockCoords = new Vector3(terrainProperties.coordinates().x, 10f, terrainProperties.coordinates().z);

                if (Input.GetMouseButtonDown(0)){
                    if(tileMarker == null)
                    {
                        tileMarker = Instantiate(tileMarkerPrefab, new Vector3(blockCoords.x, 0.3f, blockCoords.z), Quaternion.identity);
                    }

                    else if (tileMarker != null)
                    {
                        tileMarker.transform.position = new Vector3(blockCoords.x, 0.3f, blockCoords.z);
                    }
                    if(player == null)
                    {
                        player = Instantiate(playerPrefab, blockCoords, Quaternion.identity);
                        player.GetComponent<PathFinder>().updateGrid();
                    }

                }
            }
        }
    }

    void rayCastToggle()
    {
        if (Input.GetButtonDown("Submit") && active == false)
        {
            active = true;
        }
        else if(Input.GetButtonDown("Submit") && active == true)
        {
            active = false;
        }
    }
}