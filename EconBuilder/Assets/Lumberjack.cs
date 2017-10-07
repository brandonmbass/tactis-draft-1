using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : CharacterBase
{
	void Start () {
		
	}

    public override void Interact()
    {
        var managers = GameObject.Find("_GLOBAL_DATA_/Managers");
        var lumberjackData = GameObject.Find("_GLOBAL_DATA_/CharacterData/LumberjackData").GetComponent<LumberjackData>();

        var dialogManager = managers.GetComponent<DialogManager>();
        dialogManager.RunDialog(DialogManager.LumberjackGreeting, this, (res) =>
        {
        });
    }
}
