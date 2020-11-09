using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Soundtoggle(bool toggle)
    {
        if (toggle)
            mixer.SetFloat("master", -80);

        else
        {
            mixer.SetFloat("master", 0);
        }
            
    }
}
