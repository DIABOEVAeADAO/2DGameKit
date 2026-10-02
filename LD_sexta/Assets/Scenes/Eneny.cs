using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eneny : MonoBehaviour
{
    [SerializeField] private AStarPathfinding pathfinding;
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float speed = 3.5f;

    private List<Node> currentPath;
    private int currentPathIndex = 0;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        if (waypoints.Count > 0)
        {
            StartCoroutine(UpdatePathRoutine());
        }
    }

    private IEnumerator UpdatePathRoutine()
    {
        while (true)
        {
            if (waypoints.Count > 0 && currentWaypointIndex < waypoints.Count)
            {
                Transform currentTarget = waypoints[currentWaypointIndex];
                currentPath = pathfinding.FindPath(transform.position, currentTarget.position);
                currentPathIndex = 0;
            }
            yield return new WaitForSeconds(0.25f);
        }
    }

    private void Update()
    {
        if (currentPath == null || currentPathIndex >= currentPath.Count)
        {
            return;
        }

        Vector3 targetPosition = currentPath[currentPathIndex].WorldPosition;
        targetPosition.y = transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentPathIndex++;
        }

        if (currentPathIndex >= currentPath.Count)
        {
            if (waypoints.Count > 0 && currentWaypointIndex < waypoints.Count)
            {
                float distanceToWaypoint = Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position);
                if (distanceToWaypoint < 0.2f)
                {
                    currentWaypointIndex++;
                }
            }
        }
    }
}