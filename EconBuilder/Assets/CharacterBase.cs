using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBase : Interactable {

    public Sprite Portrait;

    public override void Interact()
    {
        var blacksmithData = GameObject.Find("_GLOBAL_DATA_").GetComponent<BlacksmithData>();

        var dialogManager = GameObject.Find("_GLOBAL_DATA_").GetComponent<DialogManager>();
        dialogManager.RunDialog(DialogManager.BrandonIsATool, this, (res) =>
        {
            var storeManager = GameObject.Find("_GLOBAL_DATA_").GetComponent<StoreManager>();
            storeManager.OpenStore(blacksmithData.Store);
        });
    }
}
