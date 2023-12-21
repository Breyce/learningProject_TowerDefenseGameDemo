using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = WayPoints.wayPoints[wavepointIndex];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
    }

    public void GetNextWayPoint()
    {
        if (wavepointIndex >= WayPoints.wayPoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = WayPoints.wayPoints[wavepointIndex];
    }
}
