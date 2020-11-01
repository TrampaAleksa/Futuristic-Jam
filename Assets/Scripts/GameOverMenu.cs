using System;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public static GameOverMenu Instance;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject gameOverUI;
    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }
}