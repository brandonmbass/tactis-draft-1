using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChatManager : GlobalBehavior {
    public bool IsActive
    {
        get
        {
            var input = UIManager.ChatEntry.GetComponent<InputField>();
            return input.isFocused;
        }
    }

    Text ChatLogText;
    InputField ChatEntryText;

    // Use this for initialization
    void Start () {
        ChatLogText = UIManager.ChatLog.GetComponent<Text>();
        ChatEntryText = UIManager.ChatEntry.GetComponent<InputField>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ProcessKey(char c)
    {
        ChatEntryText.text += c;
    }
}
