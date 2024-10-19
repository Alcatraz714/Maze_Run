using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public int currentLevel;
    public void LoadNextLevel()
    {
        currentLevel++;
        string nextLevelName = "Level" + currentLevel;
        SceneManager.LoadScene(nextLevelName);
    }
}
