using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {

    public GameObject settingsDialog;
    public GameObject ui;

    BuildingManager BuildingManager;

    // Use this for initialization
    void Start () {
        BuildingManager = GetComponent<BuildingManager>();

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
}
