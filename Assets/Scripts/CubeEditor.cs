using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    TextMesh textMesh;
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    private void Start()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = "test";
    }

    private void Update()
    {
        SnapToGrid();

        UpdateLabel();
    }

    private void SnapToGrid()
    {
        transform.position = new Vector3(waypoint.GetGridPos().x, 0f, waypoint.GetGridPos().y);
    }

    private void UpdateLabel()
    {
        string labelText = waypoint.GetGridPos().x / waypoint.GetGridSize()+ " , " + waypoint.GetGridPos().y / waypoint.GetGridSize();
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
