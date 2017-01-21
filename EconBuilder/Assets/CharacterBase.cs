using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBase : Interactable {

    public Sprite Portrait;

    public override void Interact()
    {
        var uiManager = GameObject.Find("_SCRIPTS_").GetComponent<UIManager>();
        uiManager.Dialog.gameObject.SetActive(true);
        uiManager.DialogText.GetComponent<Text>().text = "Hello world";
        uiManager.DialogImage.GetComponent<Image>().sprite = Portrait;
    }
}
