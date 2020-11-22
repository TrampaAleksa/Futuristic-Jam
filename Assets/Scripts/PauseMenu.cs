using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;
    public static bool GameIsPaused = false;
    public GameObject nextLevel;
    public GameObject playAgain;
    public GameObject tryAgain;
    public GameObject pauseMenuUi;
    void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }    
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void ActivateNextMenu(bool activate)
    {
        ToggleMenu(activate, nextLevel);
    }
    public void ActivatePlayAgainMenu(bool activate)
    {
        ToggleMenu(activate, playAgain);
    }
    public void ActivateTryAgainMenu(bool activate)
    {
        ToggleMenu(activate, tryAgain);
    }
    public void CallNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex+1 >= SceneManager.sceneCountInBuildSettings)
        {
            ActivatePlayAgainMenu(true);
        }
        else
        {
            ActivateNextMenu(true);
        }
    }
    public void ToggleMenu(bool isActive, GameObject gameObject)
    {
        gameObject.SetActive(isActive);
        if (isActive)
            Time.timeScale = 0;
        else
        {
            Time.timeScale = 1;
        }
    }
    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void TryAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene("Final Scene");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}