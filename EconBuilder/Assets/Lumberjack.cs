using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : CharacterBase
{
	void Start () {
		
	}

    public override void Interact()
    {
        var lumberjackData = GameObject.Find("_GLOBAL_DATA_/CharacterData/LumberjackData").GetComponent<LumberjackData>();
        
        GlobalData.DialogManager.RunDialog(DialogManager.LumberjackGreeting, this, (res) =>
        {
        });
    }
}
