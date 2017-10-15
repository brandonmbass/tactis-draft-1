using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestStatus
{
    NotStarted,
    Started,
    Abandoned,
    Failed,
    Completed
}

public class Quest
{
    public List<Quest> SubQuests { get; set; }
    IEnumerator<Quest> CurrentSubQuest { get; set; }

    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public QuestStatus Status { get; set; }
    public Func<bool> CanComplete { get; set; }
    public Action Complete { get; set; }


    // Dialog support
    public string ProgressQuestion { get; set; }
    public string DoneAnswer { get; set; }
    public string NotDoneAnswer { get; set; }



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
            if (args.IsPressed(KeyCode.L))
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
