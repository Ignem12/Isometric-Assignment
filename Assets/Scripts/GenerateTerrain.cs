using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GenerateTerrain : MonoBehaviour
{
    [SerializeField] private GameObject grass;
    [SerializeField] private GameObject dirt;
    [SerializeField] private GameObject stone;
    private GameObject[] blocks;
    private Vector3 pos;
    [SerializeField] private Button button;
    [SerializeField] private Transform panel;
    private TMP_Text button_text;
    private GenerateObstacle genobs;
    void Start()
    {
        blocks = new GameObject[3];
        button_text = button.transform.Find("Button Coords").gameObject.GetComponent<TMP_Text>();
        genobs = button.GetComponent<GenerateObstacle>();
        blocks[0] = grass;
        blocks[1] = dirt;
        blocks[2] = stone;
        generateTerrain();
    }

    void generateTerrain()
    {
        for (int i = 0; i < 10; i++) {
            for (int j = 0; j < 10; j++)
            {
                pos = new Vector3(i, 0, j);
                Instantiate(blocks[UnityEngine.Random.Range(0, 3)], pos, Quaternion.identity);
                button_text.text = i+", "+j;
                genobs.coords = pos;
                Instantiate(button, panel);
                
            }
        }
    }
}
