using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Enemy enemy;
    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = WayPoints.wayPoints[wavepointIndex];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    public void GetNextWayPoint()
    {
        if (wavepointIndex >= WayPoints.wayPoints.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = WayPoints.wayPoints[wavepointIndex];
    }

    void EndPath()
    {
        Destroy(gameObject);
        PlayerStates.Lives--;
    }
}
