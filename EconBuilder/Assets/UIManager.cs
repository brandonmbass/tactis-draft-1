using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : GlobalBehavior {

    public GameObject settingsDialog;
    public GameObject ui;
    public GameObject Sundial;
    public GameObject Sun;
    public GameObject ChatLog;
    public GameObject ChatEntry;
    public GameObject Dialog;
    public GameObject DialogImage;
    public GameObject DialogText;

    // Use this for initialization
    void Start () {
        Init();

        Sundial = ui.transform.Find("Sundial").gameObject;
        Sun = Sundial.transform.Find("Sun").gameObject;
        ChatLog = ui.transform.Find("ChatBox/Chat Log").gameObject;
        ChatEntry = ui.transform.Find("ChatBox/Chat Entry").gameObject;
        Dialog = ui.transform.Find("Dialog").gameObject;
        DialogImage = ui.transform.Find("Dialog/Image").gameObject;
        DialogText = ui.transform.Find("Dialog/Text").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
	    

	}

    public void ToggleSettingsDialog()
    {
        this.settingsDialog.SetActive(!settingsDialog.activeSelf);
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
