using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBase : Interactable {

    public Sprite Portrait;

    public override void Interact()
    {
        var dialogManager = GameObject.Find("_SCRIPTS_").GetComponent<DialogManager>();
        dialogManager.RunDialog(DialogManager.BrandonIsATool, this);
    }
}
