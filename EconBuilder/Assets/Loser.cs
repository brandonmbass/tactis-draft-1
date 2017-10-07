using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loser : CharacterBase
{
    void Start()
    {

    }

    public override void Interact()
    {
        var managers = GameObject.Find("_GLOBAL_DATA_/Managers");
        var loserData = GameObject.Find("_GLOBAL_DATA_/CharacterData/LoserData").GetComponent<LoserData>();
        var playerQuestData = GameObject.Find("_GLOBAL_DATA_/CharacterData/CurrentCharacterData").GetComponent<QuestData>();

        var dialogManager = managers.GetComponent<DialogManager>();
        var chatManager = managers.GetComponent<ChatManager>();
        dialogManager.RunDialog(DialogManager.LoserGreeting, this, (res) =>
        {
            if (res == DialogResult.Res1.Result)
            {
                // Player accepted the quest
                playerQuestData.Quests.Add(loserData.theSolemnPromise);
                chatManager.AddText("Entry added to log.");
            }
        });
    }
}
