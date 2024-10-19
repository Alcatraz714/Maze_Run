using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public GameObject heartsContainer;
    public GameObject endGameUI;
    public TextMeshProUGUI timerText;

    public Image[] heartsImages;

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
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateLevel(int level)
    {
        levelText.text = "Level: " + level;
    }

    public void UpdateHearts(int health)
    {
        for (int i = 0; i < heartsImages.Length; i++)
        {
            heartsImages[i].enabled = i < health;
        }
    }

    public void ShowEndGameScreen()
    {
        endGameUI.SetActive(true);
    }

    public void UpdateTimer(float time)
    {
        timerText.text = "Time: " + Mathf.Ceil(time);
    }
}
