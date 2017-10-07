using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour {
    public List<Quest> Quests { get; set; }

    public QuestData()
    {
        Quests = new List<Quest>();
    }
}
