using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] bool isRunning = true;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    private void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        Pathfind();
        //ExploreNeighbours();
    }

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            HaltIfEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
        }

        print("finished");
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("haltifendfound");
            isRunning = false;
        }
    }

    private void ExploreNeighbours(Waypoint from)
    {
        if (!isRunning)
        {
            return;
        }

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = (from.GetGridPos() + direction);
            try
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
            catch { }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored)
        {
        }
        else
        {
            neighbour.SetTopColor(Color.blue);
            queue.Enqueue(neighbour);
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.grey);
        endWaypoint.SetTopColor(Color.magenta);
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
                waypoint.SetTopColor(Color.cyan);
            }
        }
    }

    private void Update()
    {
        
    }
}
