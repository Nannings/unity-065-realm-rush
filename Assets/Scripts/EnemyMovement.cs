using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;

    private void Start()
    {
        //StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        print("start patrol");
        foreach (Waypoint wayPoint in path)
        {
            transform.position = wayPoint.transform.position;
            print(wayPoint.name);
            yield return new WaitForSeconds(1);
        }
        print("end patrol");
    }
}
