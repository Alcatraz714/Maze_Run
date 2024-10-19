using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float chaseRange = 5f;
    public float moveSpeed = 3f;

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }
}
