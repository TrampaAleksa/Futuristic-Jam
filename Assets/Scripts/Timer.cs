using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    static public float currentTime = 0;
    public float startingTime = 255;
    void Start()
    {
        currentTime = startingTime;
        EnergyBarController.Instance.SetStartTime(currentTime);
    }

    
    
    void Update()
    {
        currentTime -= Time.deltaTime;
        EnergyBarController.Instance.SetTime(currentTime);
        if (currentTime <= 0)
        {
            PauseMenu.Instance.TryAgain();
        }
    }
}
