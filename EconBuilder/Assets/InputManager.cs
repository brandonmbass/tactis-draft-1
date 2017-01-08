using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    BuildingManager buildingManager;
    UIManager uiManager;
    UserActionManager userActionManager;
    ResourceManager resourceManager;

    // Use this for initialization
    void Start () {
        buildingManager = GetComponent<BuildingManager>();
        uiManager = GetComponent<UIManager>();
        userActionManager = GetComponent<UserActionManager>();
        resourceManager = GetComponent<ResourceManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (buildingManager.isPlacing)
        {
            // Input handled by BuildingManager
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiManager.ToggleSettingsDialog();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            // Use Q action
            userActionManager.Chop();
        }

    }
}
