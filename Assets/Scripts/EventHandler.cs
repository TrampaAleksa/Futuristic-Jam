using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventHandler : MonoBehaviour
{

    public GameObject chatPanel, textObject;
    public List<Message> messagelist = new List<Message>();
    public int maxmessages = 25;

    public void SendMessageToChat(string text)
    {
        if (messagelist.Count >= maxmessages)
        {
            Destroy(messagelist[0].textObject.gameObject);
            messagelist.Remove(messagelist[0]);
        }

        Message newMessage = new Message();
        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);
        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;

        messagelist.Add(newMessage);
    }
}
[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;

}
