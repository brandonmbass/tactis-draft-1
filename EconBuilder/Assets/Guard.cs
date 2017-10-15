using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : CharacterBase
{
    void Start()
    {

    }

    public override void Interact()
    {
        var guardData = GameObject.Find("_GLOBAL_DATA_/CharacterData/GuardData").GetComponent<GuardData>();
        var playerQuestData = GameObject.Find("_GLOBAL_DATA_/CharacterData/CurrentCharacterData").GetComponent<QuestData>();
        
        if (playerQuestData.Quests.Contains(guardData.MakeArrows))
        {
            if (guardData.MakeArrows.Status == QuestStatus.Started)
            {
                G.DialogManager.RunQuestDialog(guardData.MakeArrows, this, (res) =>
                {
                });
                return;
            }
        }

        G.DialogManager.RunDialog(DialogManager.GuardGreeting, this, (res) =>
        {
            if (res == DialogResult.Res1.Result)
            {
                // Player accepted the quest
                playerQuestData.Quests.Add(guardData.MakeArrows);
                guardData.MakeArrows.Status = QuestStatus.Started;
                G.ChatManager.AddText("Entry added to log.");
            }
        });
    }
}
