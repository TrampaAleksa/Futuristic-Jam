using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public int indexOfMaxLastLevel;
    public static int lastLevel;
    public static LevelChanger Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void OnLevelWasLoaded(int level)
    {
        if (indexOfMaxLastLevel < level)
        {
            indexOfMaxLastLevel = level;
        }
    }

    public void RoundFinished()
    {
        OnLevelWasLoaded(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public int GetIndexOfLevel()
    {
        return indexOfMaxLastLevel;
    }
}
