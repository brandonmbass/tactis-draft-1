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
        var managers = GameObject.Find("_GLOBAL_DATA_/Managers");
        var guardData = GameObject.Find("_GLOBAL_DATA_/CharacterData/GuardData").GetComponent<GuardData>();
        var playerQuestData = GameObject.Find("_GLOBAL_DATA_/CharacterData/CurrentCharacterData").GetComponent<QuestData>();

        var dialogManager = managers.GetComponent<DialogManager>();
        var chatManager = managers.GetComponent<ChatManager>();
        dialogManager.RunDialog(DialogManager.GuardGreeting, this, (res) =>
        {
            if (res == DialogResult.Res1.Result)
            {
                // Player accepted the quest
                playerQuestData.Quests.Add(guardData.MakeArrows);
                chatManager.AddText("Entry added to log.");
            }
        });
    }
}
