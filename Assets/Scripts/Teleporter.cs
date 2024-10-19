using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportTarget;
    public float offset = 1.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 newPosition = teleportTarget.position;
            // Adjust the player's position slightly after teleportation based on their current direction
            Vector3 direction = (other.transform.position - transform.position).normalized;
            newPosition += direction * offset;

            other.transform.position = newPosition;
        }
    }
}
