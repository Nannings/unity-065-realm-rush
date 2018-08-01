using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    private void Start()
    {
        LoadBlocks();
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());
            if (isOverlapping)
            {
                Debug.Log("Overlapping: " + waypoint.GetGridPos());
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }

    private void Update()
    {
        
    }
}
