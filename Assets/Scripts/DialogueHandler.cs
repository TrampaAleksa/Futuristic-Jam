using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour
{
   public Text dialogue;
   public GameObject dialogueHolder;

   public static DialogueHandler Instance;
   private TimedAction timedAction;


   private void Awake()
   {
      Instance = this;
      timedAction = gameObject.AddComponent<TimedAction>();
   }

   public void ShowDialogue(string text, float time)
   {
      dialogue.text = text;
      dialogueHolder.SetActive(true);
      timedAction.StartTimedAction(() => dialogueHolder.SetActive(false), time);
   }

   public void ShowDialogue(string text)
   {
      dialogue.text = text;
      dialogueHolder.SetActive(true);
   }
   
}
