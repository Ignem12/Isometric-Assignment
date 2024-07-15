using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObsPanel : MonoBehaviour
{
    [SerializeField] private Transform panel;
    public void toggleObstaclePanel()
    {
        if (panel.gameObject.activeSelf == true)
        {
            panel.gameObject.SetActive(false);
        }
        else
        {
            panel.gameObject.SetActive(true);
        }
    }
}
