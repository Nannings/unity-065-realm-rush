using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Block> path;

    private void Start()
    {
        PrintAllWayPoint();
    }

    private void PrintAllWayPoint()
    {
        foreach (Block wayPoint in path)
        {
            print(wayPoint.name);
        }
    }
}
