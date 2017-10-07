using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public List<Quest> SubQuests { get; set; }
    IEnumerator<Quest> CurrentSubQuest { get; set; }

    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }

    public Quest()
    {
        SubQuests = new List<Quest>();
    }
}

// TODO: delete or not. hmm.
public class QuestManager : GlobalBehavior {

    void Start()
    {
        InputManager.KeyPressed.AddListener((args) =>
        {
            if (args.IsPressed(KeyCode.Q))
            {
                UIManager.ToggleQuestDialog();
            }

            return args;
        });
    }

    public void AddQuest(Quest quest)
    {

    }
}
