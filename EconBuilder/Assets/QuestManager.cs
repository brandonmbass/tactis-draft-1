using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public List<Quest> SubQuests { get; set; }
    IEnumerator<Quest> CurrentQuest { get; set; }

    public Quest()
    {
        SubQuests = new List<Quest>();
    }
}

public class QuestManager : GlobalBehavior {
    
    public void AddQuest(Quest quest)
    {

    }
}
