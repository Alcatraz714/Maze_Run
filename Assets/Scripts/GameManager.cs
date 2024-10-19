using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int playerHealth = 2;
    public int playerScore = 0;
    public int currentLevel = 1;
    public float levelTime = 60f; // Time limit per level
    public float speedBoostDuration = 5f;
    public float invincibilityDuration = 5f;

    private float currentTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentTime = levelTime;
        UIManager.Instance.UpdateTimer(currentTime);
    }

    private void Update()
    {
        // Countdown timer for the level
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UIManager.Instance.UpdateTimer(currentTime);
        }
        else
        {
            UpdateHealth(-1); // Player loses a heart if time runs out
            currentTime = levelTime; // Reset timer for retry or next level
        }
    }

    public void UpdateHealth(int value)
    {
        playerHealth += value;
        if (playerHealth <= 0)
        {
            EndGame();
        }
        UIManager.Instance.UpdateHearts(playerHealth);
    }

    public void AddScore(int points)
    {
        playerScore += points;
        UIManager.Instance.UpdateScore(playerScore);
    }

    public void CompleteLevel()
    {
        currentLevel++;
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        string nextLevelName = "Level" + currentLevel;
        SceneManager.LoadScene(nextLevelName);
        currentTime = levelTime;
    }

    public void EndGame()
    {
        UIManager.Instance.ShowEndGameScreen();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
        playerHealth = 2;
        playerScore = 0;
        currentLevel = 1;
        currentTime = levelTime;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ActivateSpeedBoost()
    {
        StartCoroutine(PlayerController.Instance.SpeedBoost(speedBoostDuration));
    }

    public void ActivateInvincibility()
    {
        StartCoroutine(PlayerController.Instance.Invincibility(invincibilityDuration));
    }
}
