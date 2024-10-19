using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    public float moveSpeed = 5f;
    private Vector2 movement;

    private bool isInvincible = false;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        // Flip the sprite based on horizontal movement
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false; // Facing right
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true; // Facing left
        }
    }

    void FixedUpdate()
    {
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            GameManager.Instance.AddScore(10);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Heart"))
        {
            GameManager.Instance.UpdateHealth(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("SpeedBoost"))
        {
            GameManager.Instance.ActivateSpeedBoost();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Invincibility"))
        {
            GameManager.Instance.ActivateInvincibility();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy") && !isInvincible)
        {
            Debug.Log("Hit by enemy");
            GameManager.Instance.UpdateHealth(-1);
        }
        else if (other.CompareTag("LevelComplete"))
        {
            GameManager.Instance.CompleteLevel();
        }
    }

    public IEnumerator SpeedBoost(float duration)
    {
        moveSpeed *= 2;
        yield return new WaitForSeconds(duration);
        moveSpeed /= 2;
    }

    public IEnumerator Invincibility(float duration)
    {
        isInvincible = true;
        yield return new WaitForSeconds(duration);
        isInvincible = false;
    }
}
