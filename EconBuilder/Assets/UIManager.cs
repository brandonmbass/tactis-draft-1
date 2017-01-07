using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public GameObject settingsDialog;

    BuildingManager BuildingManager;

    // Use this for initialization
    void Start () {
        BuildingManager = GetComponent<BuildingManager>();

    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape) && !BuildingManager.isPlacing)
        {
            ToggleSettingsDialog();
        }
	}

    public void ToggleSettingsDialog()
    {
        this.settingsDialog.SetActive(!settingsDialog.activeSelf);
    }
}
