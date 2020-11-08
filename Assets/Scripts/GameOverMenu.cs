using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        // StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene("UIMenu");
    }

    private void Update()
    {
        //print("update");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Final Scene 1");
    }
    
    public void LoadMenu()
    {
        print("load main menu");
        SceneManager.LoadScene("UIMenu");
    }
}