using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBase : Interactable {

    public Sprite Portrait;

    public override void Interact()
    {
        var managers = GameObject.Find("_GLOBAL_DATA_/Managers");
        var blacksmithData = GameObject.Find("_GLOBAL_DATA_/CharacterData").GetComponent<BlacksmithData>();

        var dialogManager = managers.GetComponent<DialogManager>();
        dialogManager.RunDialog(DialogManager.BrandonIsATool, this, (res) =>
        {
            var storeManager = managers.GetComponent<StoreManager>();
            storeManager.OpenStore(blacksmithData.Store);
        });
    }
}
