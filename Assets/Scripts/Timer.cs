using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    static public float currentTime = 0;
    public float startingTime = 10;
    void Start()
    {
        currentTime = startingTime;
    }

    
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        EnergyBarController.Instance.SetTime(currentTime);
        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }
}
