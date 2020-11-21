﻿using UnityEngine;

public class DialogueCollisionTrigger : MonoBehaviour
{
    public float timeToShow;
    public string textToShow;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (timeToShow != 0)
            {
                DialogueHandler.Instance.ShowDialogue(textToShow, timeToShow);
            }
            else
            {
                DialogueHandler.Instance.ShowDialogue(textToShow);
            }
        }
    }
}