using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBase : Interactable {

    public Sprite Portrait;

    public override void Interact()
    {
        var blacksmithData = GameObject.Find("_GLOBAL_DATA_/CharacterData/BlacksmithData").GetComponent<BlacksmithData>();
        
        G.DialogManager.RunDialog(DialogManager.BrandonIsATool, this, (res) =>
        {
            G.StoreManager.OpenStore(blacksmithData.Store);
        });
    }
}
