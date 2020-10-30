using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class dialogue : MonoBehaviour
{
    string[] text;
    public Text textfield;
    int i = 0;
    private void Awake()
    {
        text = ReadFromFile();
    }
    private void Start()
    {
        textfield.text = text[i];
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShowNextMessage();
        }
        if (Input.GetMouseButtonDown(1))
        {
            ShowPreviousMessage();
        }
    }
    public void ShowNextMessage()
    {
        if (i < text.Length-2)
        {
            i++;
            textfield.text = text[i];
        }
    }
    public void ShowPreviousMessage()
    {
        if (i > 0)
        {
            i--;
            textfield.text = text[i];
        }
    }
    string[] ReadFromFile()
    {
        StreamReader sr = new StreamReader("Assets/Resources/dialogue.txt", true);
        string alltext = sr.ReadToEnd();
        string[] text = alltext.Split('$');
        text[0] = "\n" + text[0];
        return text;
    }
}
