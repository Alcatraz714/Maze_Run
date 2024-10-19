using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;  // Array of patrol points
    public float moveSpeed = 2f;      // Speed at which the enemy moves
    private int currentPointIndex = 0; // Current patrol point the enemy is moving toward

    private void Update()
    {
        if (patrolPoints.Length == 0) return;

        // Move the enemy towards the current patrol point
        Transform targetPoint = patrolPoints[currentPointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

        // If the enemy reaches the patrol point, switch to the next point
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }
    }
}
