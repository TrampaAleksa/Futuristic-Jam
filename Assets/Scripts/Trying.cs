using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trying : MonoBehaviour
{
    EventHandler level;
    public InputField text;
    public void Awake()
    {
        level = GetComponent<EventHandler>();
    }
    public void AddText()
    {
        level.SendMessageToChat(text.text);
    }

}
