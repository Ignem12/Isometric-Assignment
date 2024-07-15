using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GenerateObstacle : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject obstacle;
    private GameObject gu;
    public Vector3 coords;
    private bool occupied = false;
    private GameObject obs;

    private void Start()
    {
        gu = GameObject.Find("ObstacleManager");
    }

    public void generateObstacle()
    {
        coords.y = 10f;

        if (occupied == false)
        {
            obs = Instantiate(obstacle, coords, Quaternion.identity);
            obs.name = coords.x.ToString() + ", " + coords.z.ToString();
            occupied = true;
            obs.transform.parent = gu.transform;
        }

        else
        {
            Destroy(obs);
            occupied = false;

        }

    }
}
