﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : GlobalBehavior {
    
    public GameObject ui;
    public GameObject settingsDialog;
    public GameObject Sundial;
    public GameObject Sun;
    public GameObject ChatLog;
    public GameObject ChatEntry;
    public GameObject DialogContainer;
    public GameObject Dialog;
    public GameObject DialogImage;
    public GameObject DialogText;
    public GameObject DialogAnswer1;
    public GameObject DialogAnswer1Text;
    public GameObject DialogAnswer2;
    public GameObject DialogAnswer2Text;
    public GameObject craftingDialog;
    public GameObject questDialog;

    // Use this for initialization
    void Start () {
        ui = GameObject.Find("UI Canvas");
        settingsDialog = ui.transform.Find("Settings").gameObject;
        Sundial = ui.transform.Find("Sundial").gameObject;
        Sun = Sundial.transform.Find("Sun").gameObject;
        ChatLog = ui.transform.Find("ChatBox/Chat Log").gameObject;
        ChatEntry = ui.transform.Find("ChatBox/Chat Entry").gameObject;
        DialogContainer = ui.transform.Find("DialogContainer").gameObject;
        Dialog = ui.transform.Find("DialogContainer/Dialog").gameObject;
        DialogImage = ui.transform.Find("DialogContainer/Dialog/Image").gameObject;
        DialogText = ui.transform.Find("DialogContainer/Dialog/Text").gameObject;
        DialogAnswer1 = ui.transform.Find("DialogContainer/Answer1").gameObject;
        DialogAnswer1Text = ui.transform.Find("DialogContainer/Answer1/Text").gameObject;
        DialogAnswer2 = ui.transform.Find("DialogContainer/Answer2").gameObject;
        DialogAnswer2Text = ui.transform.Find("DialogContainer/Answer2/Text").gameObject;
        craftingDialog = ui.transform.Find("CraftingWindow").gameObject;
        questDialog = ui.transform.Find("QuestWindow").gameObject;
    }
	
    public void ToggleSettingsDialog()
    {
        this.settingsDialog.SetActive(!settingsDialog.activeSelf);
    }

    public void ToggleCraftingDialog()
    {
        this.craftingDialog.SetActive(!craftingDialog.activeSelf);
    }

    public void ToggleQuestDialog()
    {
        var list = questDialog.transform.Find("LeftPanel/QuestList/Viewport/Content");
        var description = questDialog.transform.Find("RightPanel/QuestText").GetComponent<Text>();

        // TODO: currently this draws copy over copy on top of each other. We could 'delete' everything, but then we lose previous selection
        // Instead, add 'AddQuest' to QuestManager, have it update the UI when the quest is added rather than regenerating each time. Alternately,
        // we could add AddQuest onto the characters quest script.

        // Load from current player
        int offset = 0;
        foreach (var quest in this.CurrentCharacterQuestData.Quests)
        {
            var itemGO = (GameObject)Instantiate(Resources.Load("Prefabs/QuestItem"), list);
            itemGO.transform.Find("Title").GetComponent<Text>().text = quest.Title;
            itemGO.transform.Find("Description").GetComponent<Text>().text = quest.ShortDescription;
            itemGO.transform.localPosition = new Vector3(itemGO.transform.localPosition.x, itemGO.transform.localPosition.y - offset, itemGO.transform.localPosition.z);
            itemGO.GetComponent<QuestItemSelectable>().SelectEvent.AddListener((args) =>
            {
                description.text = quest.LongDescription;
            });

            offset += 85;
        }

        this.questDialog.SetActive(!questDialog.activeSelf);
    }

    public void Click()
    {
        // TODO: specify what we want to click (probably something like ActionType.Chop, but maybe just reuse ResourceType enum)
        // TODO: Execute runs the handler as well; but do we want that? (currently we 'run' the functionality from calling code; maybe should change that)
        var button1 = ui.transform.Find("ActionButtons/Button1");
        ExecuteEvents.Execute(button1.gameObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
    }

    // Position should be 0-1.0f
    public void SetSundial(float position)
    {
        Sun.transform.rotation = Quaternion.Euler(0, 0, -135 * position);
    }
}
