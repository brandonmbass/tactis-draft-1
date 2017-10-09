using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestWindow : MonoBehaviour {

    Transform questList { get; set; }
    Text questDescription { get; set; }
    List<Quest> Quests { get; set; }


    void Start () {
        Init();
    }	

    private void Init()
    {
        // TODO: Start isn't called until this is active, but it's possible we add quests before the dialog is active...I think...
        // how to organize this? Force init on startup? 
        // Also, the Quests object has to stay in sync with the user's own - maybe make it an ObservableList, and add items here as needed?
        if (Quests != null)
        {
            return;
        }

        questList = transform.Find("LeftPanel/QuestList/Viewport/Content");
        questDescription = transform.Find("RightPanel/QuestText").GetComponent<Text>();
        Quests = new List<Quest>();
    }

    public void AddQuest(Quest quest)
    {
        Init();
        if (Quests.Contains(quest))
        {
            Debug.Log("Duplicate quest added to quest window: " + quest.Title);
            return;
        }        

        var itemGO = (GameObject)Instantiate(Resources.Load("Prefabs/QuestItem"), questList);
        itemGO.transform.Find("Title").GetComponent<Text>().text = quest.Title;
        itemGO.transform.Find("Description").GetComponent<Text>().text = quest.ShortDescription;
        itemGO.transform.localPosition = new Vector3(itemGO.transform.localPosition.x, itemGO.transform.localPosition.y - Quests.Count * 85, itemGO.transform.localPosition.z);
        itemGO.GetComponent<EconSelectable>().SelectEvent.AddListener((args) =>
        {
            questDescription.text = quest.LongDescription;
        });

        Quests.Add(quest);
    }

    // TODO: move to a base class
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
