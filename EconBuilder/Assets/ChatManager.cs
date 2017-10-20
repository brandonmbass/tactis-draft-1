using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

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
    Func<EconEventArgs, EconEventArgs> ActiveKeypressHandler;
    bool active = false;

    // Use this for initialization
    void Start () {
        ChatLogText = UIManager.ChatLog.GetComponent<Text>();
        ChatEntryText = UIManager.ChatEntry.GetComponent<InputField>();
        G.InputManager.KeyPressed.AddListener((args) =>
        {
            // TODO: so, there's a bit of a problem with priority. How do we tell the system that we should get key presses first?
            // Probably just need a way to increase our own priority with the InputManager. Needs some thought.
            if (!active)
            {
                if (args.IsPressed(KeyCode.Return))
                {
                    ActivateTextInput();
                }
                else if (args.IsPressed(KeyCode.Slash))
                {
                    ActivateTextInput();
                    ChatEntryText.text += "/";
                }

                return args;
            }
            else
            {
                if (args.IsPressed(KeyCode.Return))
                {
                    AddText(ChatEntryText.text);
                    ChatEntryText.text = "";
                    DeactivateTextInput();
                }
                else
                {
                    foreach (var key in args.KeysPressed)
                    {
                        if (key >= KeyCode.A && key <= KeyCode.Z)
                        {
                            var ch = key.ToString();
                            // TODO: why doesn't this shift logic work?
                            if (!args.IsPressed(KeyCode.LeftShift) && !args.IsPressed(KeyCode.RightShift)) // TODO: capslock
                            {
                                ch = ch.ToLower();
                            }
                            ChatEntryText.text += ch;
                        }
                    }
                }

                return args.RemoveAllKeys();
            }
        });
    }
	
    public void AddText(string text)
    {
        ChatLogText.text += text + "\n";
    }

    public void ActivateTextInput()
    {
        active = true;
    }

    public void DeactivateTextInput()
    {
        active = false;
    }
}
